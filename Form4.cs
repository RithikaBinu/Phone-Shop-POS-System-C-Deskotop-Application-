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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadCategoriesData();
        }


        private void LoadCategoriesData()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName, Description FROM Categories";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Category Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@name, @desc)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@desc", textBox3.Text.Trim());
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Category added successfully!");
            LoadCategoriesData();


            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Category ID and Name are required for updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Categories SET CategoryName = @name, Description = @desc WHERE CategoryID = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@desc", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Category updated successfully!");
                    else
                        MessageBox.Show("Category ID not found.");
                }
            }
            LoadCategoriesData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter a Category ID to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE CategoryID = @id";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", textBox4.Text.Trim());
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Category deleted.");
                        else
                            MessageBox.Show("Category ID not found.");
                    }
                }
                LoadCategoriesData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                // If search box is empty, load everything
                LoadCategoriesData();
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName, Description FROM Categories WHERE CategoryID = @id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", textBox4.Text.Trim());

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
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

