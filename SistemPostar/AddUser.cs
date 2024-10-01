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
    public partial class AddUser : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public TextBox firstname, lastname, username, phone, password;
        public ComboBox role, pikePostareInput, zoneMbulimiInput;
        public string pikePostareQuery = "";
        public string zoneMbulimiQuery = "";
        public string pikePostareValue = "";
        public string zoneMbulimiValue = "";
        int userId = 0;
        int currentUserStatus = 0;

        public AddUser()
        {
            InitializeComponent();
            PopulateRoleComboBox();
            firstname = firstnameForm;
            lastname = lastnameForm;
            username = usernameForm;
            phone = phoneForm;
            password = passwordForm;
            role = roleForm;
            pikePostareInput = pikePostareForm;
            zoneMbulimiInput = zoneMbulimiForm;
            updatePikePostareComboBox(false);
            updateZoneMbulimiComboBox(false);
        }
        
        public void updatePikePostareComboBox(bool visibility)
        {
            pikePostareInput.Visible = visibility;
            pikePostareLabel.Visible = visibility;
        }

        public void updateZoneMbulimiComboBox(bool visibility, bool enabled = true)
        {
            zoneMbulimiInput.Visible = visibility;
            zoneMbulimiLabel.Visible = visibility;
            zoneMbulimiInput.Enabled = enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isUpdate = true;
            if (!checkInputs(isUpdate))
            {
                MessageBox.Show("Please fill in all the fields!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "";
            if (userId == 0)
            {
                query = "INSERT INTO Users(role_id, status, firstname, lastname, username, password, phone" + pikePostareQuery + "" + zoneMbulimiQuery + ") VALUES(@role, @status, @firstname, @lastname, @username, @password, @phone" + pikePostareValue + "" + zoneMbulimiValue + ")";
                updateUsersTable(query, false);
            }else
            {
                query = "UPDATE Users SET firstname = @firstname, lastname = @lastname, username = @username, phone = @phone, role_id = @role, updated_at = @updated_at WHERE user_id = @userId";
                updateUsersTable(query, true);
            }
        }

        private void roleForm_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private bool checkInputs(bool isUpdate)
        {
            if (string.IsNullOrEmpty(firstname.Text.Trim()))
            { 
                return false; 
            }
            if (string.IsNullOrEmpty(lastname.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(password.Text.Trim()) && !isUpdate)
            {
                return false;
            }
            if (string.IsNullOrEmpty(phone.Text.Trim()))
            {
                return false;
            }
            if (role.SelectedIndex == -1)
            {
                return false;
            }
            int selectedRoleIndex = ((KeyValuePair<int, string>)role.SelectedItem).Key;
            if (selectedRoleIndex == Convert.ToInt32(ConfigurationManager.AppSettings["SportelistId"]) || selectedRoleIndex == Convert.ToInt32(ConfigurationManager.AppSettings["TransportuesId"]) || selectedRoleIndex == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
            {
                if (pikePostareInput.SelectedIndex == -1)
                {
                    return false;
                }
                if (selectedRoleIndex == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
                {
                    if (zoneMbulimiInput.SelectedIndex == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void roleForm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (role.SelectedIndex != -1)
            {
                int roleSelectedIndex = ((KeyValuePair<int, string>)role.SelectedItem).Key;
                zoneMbulimiForm.SelectedIndex = -1;
                zoneMbulimiInput.Items.Clear();
                if (roleSelectedIndex == Convert.ToInt32(ConfigurationManager.AppSettings["SportelistId"]) || roleSelectedIndex == Convert.ToInt32(ConfigurationManager.AppSettings["TransportuesId"]) || roleSelectedIndex == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
                {
                    pikePostareInput.Items.Clear();
                    updatePikePostareComboBox(true);
                    updateZoneMbulimiComboBox(false, false);
                    zoneMbulimiQuery = "";
                    zoneMbulimiValue = "";
                    PopulatePikePostareComboBox();
                    if (roleSelectedIndex == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
                    {
                        updateZoneMbulimiComboBox(true, false);
                    }
                }
                else
                {
                    pikePostareQuery = "";
                    pikePostareValue = "";
                    zoneMbulimiQuery = "";
                    zoneMbulimiValue = "";
                    updatePikePostareComboBox(false);
                    updateZoneMbulimiComboBox(false);
                }
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
        }

        private void PopulateRoleComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name FROM Roles WHERE status = 1", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["name"].ToString();

                            roleForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            roleForm.DisplayMember = "Value";
            roleForm.ValueMember = "Key";
        }

        private void pikePostareForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikePostareInput.SelectedIndex == -1)
            {
                return;
            }
            if (((KeyValuePair<int, string>)role.SelectedItem).Key == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
            {
                updateZoneMbulimiComboBox(true, true);
                zoneMbulimiInput.Items.Clear();
                PopulateZonaMbullimiComboBox(((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key);
            }
            pikePostareQuery = ",pike_postare_id";
            pikePostareValue = ",@pike_postare_id";
        }

        private void zoneMbulimiForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zoneMbulimiInput.SelectedIndex == -1)
            {
                return;
            }
            zoneMbulimiQuery = ",zone_mbulimi_id";
            zoneMbulimiValue = ",@zone_mbulimi_id";
        }

        private void PopulatePikePostareComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name FROM PikatPostare WHERE status = 1", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["name"].ToString();

                            pikePostareInput.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }
            pikePostareInput.DisplayMember = "Value";
            pikePostareInput.ValueMember = "Key";
        }

        private void PopulateZonaMbullimiComboBox(int pikePostareId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name FROM ZonaMbulimi WHERE status = 1 AND pike_postare_id = @pike_postare_id", connection))
                {
                    command.Parameters.AddWithValue("@pike_postare_id", pikePostareId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["name"].ToString();

                            zoneMbulimiInput.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }
            zoneMbulimiInput.DisplayMember = "Value";
            zoneMbulimiInput.ValueMember = "Key";
        }

        private void updateUsersTable(string query, bool update)
        {
            try
            {
                int zoneMbulimiId = 0, pikePostareId = 0;
                if (pikePostareInput.SelectedIndex != -1)
                {
                    pikePostareId = ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key;
                }
                if (zoneMbulimiInput.SelectedIndex != -1)
                {
                    zoneMbulimiId = ((KeyValuePair<int, string>)zoneMbulimiInput.SelectedItem).Key;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", firstname.Text);
                        command.Parameters.AddWithValue("@lastname", lastname.Text);
                        command.Parameters.AddWithValue("@username", username.Text);
                        command.Parameters.AddWithValue("@phone", phone.Text);
                        command.Parameters.AddWithValue("@role", ((KeyValuePair<int, string>)role.SelectedItem).Key);
                        command.Parameters.AddWithValue("@pike_postare_id", pikePostareId);
                        command.Parameters.AddWithValue("@zone_mbulimi_id", zoneMbulimiId);
                        if (!update)
                        {
                            using (SHA256 sha256 = SHA256.Create())
                            {
                                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password.Text));
                                string hashedEnteredPassword = BitConverter.ToString(hashedBytes).Replace("-", "");
                                command.Parameters.AddWithValue("@password", hashedEnteredPassword);
                            }
                            command.Parameters.AddWithValue("@status", currentUserStatus);
                        } else
                        {
                            command.Parameters.AddWithValue("@status", currentUserStatus);
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                        }
                        if (command.ExecuteNonQuery() > 0)
                        {
                            if (update)
                            {
                                MessageBox.Show("Successfully updated user!");
                            }
                            else
                            {
                                MessageBox.Show("Successfully added user!");
                            }
                            clearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void clearInputs()
        {
            firstnameForm.Text = string.Empty;
            lastnameForm.Text = string.Empty;
            usernameForm.Text = string.Empty;
            passwordForm.Text = string.Empty;
            phoneForm.Text = string.Empty;
            roleForm.SelectedIndex = -1;
            zoneMbulimiInput.Items.Clear();
            updatePikePostareComboBox(false);
            updateZoneMbulimiComboBox(false);
        }

        public void setUserId(int user_id)
        {
            userId = user_id;
        }

        public void setCurrentUserStatus(int status)
        {
            currentUserStatus = status;
        }
    }
}
