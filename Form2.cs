using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace I_CARE_Phone_Shop_C__Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            {
                string username = textBox1.Text.Trim();
                string password = textBox2.Text;
                string confirmPassword = textBox3.Text;

                // 1. Validate empty fields
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Check if passwords match (Based on your new Confirm Password field)
                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Hash the password before saving
                string hashedPassword = DatabaseHelper.HashPassword(password);

                // 4. Save to Database
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users (Username, PasswordHash) VALUES (@user, @pass)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@user", username);
                        command.Parameters.AddWithValue("@pass", hashedPassword);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Account created successfully! You can now log in.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Closes the register form and goes back to login
                        }
                        catch (SQLiteException ex)
                        {
                            if (ex.ResultCode == SQLiteErrorCode.Constraint)
                            {
                                MessageBox.Show("This username already exists. Please choose another.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Database Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
