using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPostar
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string enteredPassword = passwordTextbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword)) 
            {
                MessageBox.Show("Make sure username and password are correctly set!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string hashedPassword = GetHashedPasswordFromDatabase(username);

            if (!string.IsNullOrEmpty(hashedPassword) && VerifyPassword(enteredPassword, hashedPassword))
            {
                this.Hide();
                int userId = getUserId(username);
                int userRoleId = getUserRoleId(username);
                Form2 form2 = new Form2();
                form2.setUserId(userId);
                form2.setUserRoleId(userRoleId);
                form2.displayUserButtons();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetHashedPasswordFromDatabase(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT password FROM Users WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    return command.ExecuteScalar() as string;
                }
            }
        }

        private int getUserId(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT user_id FROM Users WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private int getUserRoleId(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT role_id FROM Users WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private bool VerifyPassword(string enteredPassword, string hashedPasswordFromDatabase)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                string hashedEnteredPassword = BitConverter.ToString(hashedBytes).Replace("-", "");

                return hashedEnteredPassword.Equals(hashedPasswordFromDatabase, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void gjurmoPorosine_Click(object sender, EventArgs e)
        {
            GjurmoPorosine gjurmo = new GjurmoPorosine();
            gjurmo.Show();
            gjurmo.setForm1(this);
            this.Hide();
        }
    }
}
