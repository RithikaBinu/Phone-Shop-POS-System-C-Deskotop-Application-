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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            LoadCustomersData();
        }

        private void LoadCustomersData()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CustomerID, CustomerName, ContactNumber, Address FROM Customers";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Customer Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Customers (CustomerName, ContactNumber, Address) VALUES (@name, @contact, @address)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@contact", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@address", textBox4.Text.Trim());

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Customer added successfully!");
            LoadCustomersData(); // Refresh the grid

            // Optional: Clear the textboxes after adding
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Customer ID and Name are required to update a record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Customers SET CustomerName = @name, ContactNumber = @contact, Address = @address WHERE CustomerID = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@contact", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@address", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim()); // Top-left ID box

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Customer updated successfully!");
                    else
                        MessageBox.Show("Customer ID not found.");
                }
            }
            LoadCustomersData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter a Customer ID to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Customers WHERE CustomerID = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", textBox6.Text.Trim()); // Bottom-right ID box
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Customer deleted.");
                        else
                            MessageBox.Show("Customer ID not found.");
                    }
                }
                LoadCustomersData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                // If the search box is empty, show all customers
                LoadCustomersData();
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CustomerID, CustomerName, ContactNumber, Address FROM Customers WHERE CustomerID = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", textBox6.Text.Trim()); // Bottom-right ID box
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
