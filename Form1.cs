using System.Data.SQLite;

namespace I_CARE_Phone_Shop_C__Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Register = new Form2();
            this.Hide();
            Register.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedInputPassword = DatabaseHelper.HashPassword(password);
            bool loginSuccess = false;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string selectQuery = "SELECT PasswordHash FROM Users WHERE Username = @user";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@user", username);
                    var result = command.ExecuteScalar();

                    if (result != null && result.ToString() == hashedInputPassword)
                    {
                        loginSuccess = true;
                    }
                }
            }

            if (loginSuccess)
            {

                Form3 dashboard = new Form3();
                this.Hide();
                dashboard.ShowDialog();
                this.Show();


                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

