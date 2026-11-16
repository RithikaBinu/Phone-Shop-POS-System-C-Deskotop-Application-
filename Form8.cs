using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace I_CARE_Phone_Shop_C__Project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            LoadAllSales();

            // Lock the grid so cashiers cannot edit history
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadAllSales()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT SaleID AS 'Bill No', SaleDate AS 'Date', CustomerID, TotalAmount AS 'Grand Total' FROM Sales ORDER BY SaleID DESC";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            LoadAllSales();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;

                // If Bill NO is entered, search by ID. Otherwise, search by Date.
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    command.CommandText = "SELECT SaleID AS 'Bill No', SaleDate AS 'Date', CustomerID, TotalAmount AS 'Grand Total' FROM Sales WHERE SaleID = @id";
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                }
                else
                {
                    // Uses LIKE to match the date part of the yyyy-MM-dd HH:mm:ss format
                    command.CommandText = "SELECT SaleID AS 'Bill No', SaleDate AS 'Date', CustomerID, TotalAmount AS 'Grand Total' FROM Sales WHERE SaleDate LIKE @date";
                    command.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%");
                }

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