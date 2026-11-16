using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace I_CARE_Phone_Shop_C__Project
{
    public partial class Form7 : Form
    {
        private DataTable cartTable;
        private decimal grandTotal = 0;

        public Form7()
        {
            InitializeComponent();
            SetupCartTable();
        }

        private void SetupCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("UnitPrice", typeof(decimal));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("LineTotal", typeof(decimal));

            // Link the cart to your large grey DataGridView
            dataGridView1.DataSource = cartTable;

            textBox7.Text = "0.00";

            // Prevent users from typing into read-only boxes
            textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox1.ReadOnly = true;
        }

        //private void txtProductID_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(textBox3.Text)) return;

        //    using (var connection = DatabaseHelper.GetConnection())
        //    {
        //        connection.Open();
        //        string query = "SELECT ProductName, UnitPrice, StockQuantity FROM Products WHERE ProductID = @id";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@id", textBox5.Text.Trim());
        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    textBox4.Text = reader["ProductName"].ToString();
        //                    textBox6.Text = reader["UnitPrice"].ToString();
        //                    textBox5.Text = reader["StockQuantity"].ToString();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    textBox4.Clear();
        //                    textBox6.Clear();
        //                    textBox5.Clear();
        //                }
        //            }
        //        }
        //    }
        //}


        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please select a valid product and enter a quantity.");
                return;
            }

            int qty = int.Parse(textBox8.Text.Trim());
            int stock = int.Parse(textBox5.Text.Trim());
            decimal price = decimal.Parse(textBox6.Text.Trim());

            // Validations
            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.");
                return;
            }
            if (qty > stock)
            {
                MessageBox.Show("Quantity exceeds available stock!");
                return;
            }

            // Calculate and add to cart
            decimal lineTotal = price * qty;
            cartTable.Rows.Add(textBox3.Text, textBox4.Text, price, qty, lineTotal);

            // Update Grand Total
            grandTotal += lineTotal;
            textBox7.Text = grandTotal.ToString("0.00");

            // Clear input boxes for the next item
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox8.Clear();

            textBox3.Focus(); // Put the cursor back to Product ID
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Subtract the removed item's total from the Grand Total
                decimal itemTotal = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["LineTotal"].Value);
                grandTotal -= itemTotal;
                textBox7.Text = grandTotal.ToString("0.00");

                // Remove the row
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a row in the cart to remove.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cannot complete a sale with an empty cart.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Create the main Sale record
                        string saleQuery = "INSERT INTO Sales (SaleDate, CustomerID, TotalAmount) VALUES (@date, @custId, @total); SELECT last_insert_rowid();";
                        long generatedSaleID = 0;

                        using (var saleCmd = new SQLiteCommand(saleQuery, connection, transaction))
                        {
                            saleCmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            saleCmd.Parameters.AddWithValue("@custId", string.IsNullOrWhiteSpace(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
                            saleCmd.Parameters.AddWithValue("@total", grandTotal);

                            // ExecuteScalar returns the new auto-incremented SaleID
                            generatedSaleID = (long)saleCmd.ExecuteScalar();
                        }

                        // Step 2: Loop through the cart to save items and reduce stock
                        foreach (DataRow row in cartTable.Rows)
                        {
                            int pId = Convert.ToInt32(row["ProductID"]);
                            int qty = Convert.ToInt32(row["Quantity"]);
                            decimal price = Convert.ToDecimal(row["UnitPrice"]);
                            decimal lTotal = Convert.ToDecimal(row["LineTotal"]);

                            // Insert into SaleItems table
                            string itemQuery = "INSERT INTO SaleItems (SaleID, ProductID, Quantity, UnitPrice, LineTotal) VALUES (@sId, @pId, @qty, @price, @lTotal)";
                            using (var itemCmd = new SQLiteCommand(itemQuery, connection, transaction))
                            {
                                itemCmd.Parameters.AddWithValue("@sId", generatedSaleID);
                                itemCmd.Parameters.AddWithValue("@pId", pId);
                                itemCmd.Parameters.AddWithValue("@qty", qty);
                                itemCmd.Parameters.AddWithValue("@price", price);
                                itemCmd.Parameters.AddWithValue("@lTotal", lTotal);
                                itemCmd.ExecuteNonQuery();
                            }

                            // Reduce StockQuantity in Products table
                            string stockQuery = "UPDATE Products SET StockQuantity = StockQuantity - @qty WHERE ProductID = @pId";
                            using (var stockCmd = new SQLiteCommand(stockQuery, connection, transaction))
                            {
                                stockCmd.Parameters.AddWithValue("@qty", qty);
                                stockCmd.Parameters.AddWithValue("@pId", pId);
                                stockCmd.ExecuteNonQuery();
                            }
                        }

                        // Step 3: Commit everything to the database
                        transaction.Commit();

                        textBox1.Text = generatedSaleID.ToString(); // Display the new Sale ID on screen
                        MessageBox.Show("Sale completed successfully! Stock has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form for the next customer
                        cartTable.Clear();
                        grandTotal = 0;
                        textBox7.Text = "0.00";
                        textBox2.Clear();
                    }
                    catch (Exception ex)
                    {
                        // If anything goes wrong, roll back changes so the database isn't corrupted
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while processing the sale: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text)) return;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT ProductName, UnitPrice, StockQuantity FROM Products WHERE ProductID = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", textBox3.Text.Trim());
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Make sure these match your actual text box names!
                            textBox4.Text = reader["ProductName"].ToString();
                            textBox6.Text = reader["UnitPrice"].ToString();
                            textBox5.Text = reader["StockQuantity"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox4.Clear();
                            textBox6.Clear();
                            textBox5.Clear();
                        }
                    }
                }
            }
        }
    }

}
    



