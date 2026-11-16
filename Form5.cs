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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            LoadProductsData();
        }

        private void LoadProductsData()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT ProductID, ProductName,CategoryID, UnitPrice, StockQuantity FROM Products";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Product Name and Unit Price are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity) VALUES (@name, @catId, @price, @qty)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@catId", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@price", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@qty", textBox6.Text.Trim());

                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Product added successfully!");
            LoadProductsData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Product ID is required to update a record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Products SET ProductName = @name, CategoryID = @catId, UnitPrice = @price, StockQuantity = @qty WHERE ProductID = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@catId", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@price", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@qty", textBox6.Text.Trim());
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0) MessageBox.Show("Product updated!");
                    else MessageBox.Show("Product ID not found.");
                }
            }
            LoadProductsData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text)) return;

            if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Products WHERE ProductID = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", textBox5.Text.Trim());
                        command.ExecuteNonQuery();
                    }
                }
                LoadProductsData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                LoadProductsData();
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE ProductID = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", textBox5.Text.Trim());
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }



}
