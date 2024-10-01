using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPostar
{
    public partial class UsersList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string dataGridColumns = "user_id,firstname,lastname,username,status,role_id,phone,created_at,updated_at";
        string roleQuery = "";
        int roleId = 0;

        public UsersList()
        {
            InitializeComponent();
            PopulateRoleComboBox();
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

                            roleComboBox.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            roleComboBox.DisplayMember = "Value";
            roleComboBox.ValueMember = "Key";
        }

        private void updateUserStatus(int newStatus)
        {
            try
            {
                if (usersGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = usersGridView.SelectedRows[0];
                    DialogResult result = MessageBox.Show("Update user?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int userId = Convert.ToInt32(selectedRow.Cells["user_id"].Value);
                        string deleteQuery = "UPDATE Users SET status = @status WHERE user_id = @id";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@status", newStatus);
                                command.Parameters.AddWithValue("@id", userId);
                                if (command.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Successfully updated user!");
                                }
                                else
                                {
                                    MessageBox.Show("Something went wrong");
                                }
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please select a row before updating user.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void showUsers_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT " + dataGridColumns + " FROM Users WHERE 1 = 1";
                if (!string.IsNullOrEmpty(firstnameSearchBox.Text.Trim()))
                {
                    selectQuery += " AND firstname LIKE @firstname";
                }
                if (!string.IsNullOrEmpty(lastnameSearchBox.Text.Trim()))
                {
                    selectQuery += " AND lastname LIKE @lastname";
                }
                if (!string.IsNullOrEmpty(usernameSearchBox.Text.Trim()))
                {
                    selectQuery += " AND username LIKE @username";
                }
                if (!string.IsNullOrEmpty(phoneSearchBox.Text.Trim()))
                {
                    selectQuery += " AND phone LIKE @phone";
                }
                if (roleId != 0)
                {
                    selectQuery += roleQuery;
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@firstname", "%" + firstnameSearchBox.Text + "%");
                    command.Parameters.AddWithValue("@lastname", "%" + lastnameSearchBox.Text + "%");
                    command.Parameters.AddWithValue("@username", "%" + usernameSearchBox.Text + "%");
                    command.Parameters.AddWithValue("@phone", "%" + phoneSearchBox.Text + "%");
                    command.Parameters.AddWithValue("@role_id", roleId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            usersGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        usersGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void clearUsersList_Click_1(object sender, EventArgs e)
        {
            firstnameSearchBox.Text = string.Empty;
            lastnameSearchBox.Text = string.Empty;
            usernameSearchBox.Text = string.Empty;
            phoneSearchBox.Text = string.Empty;
            roleComboBox.SelectedIndex = -1;
            roleQuery = "";
            roleId = 0;
        }

        private void roleComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (roleComboBox.SelectedIndex != -1)
            {
                roleQuery = " AND role_id = @role_id";
                roleId = ((KeyValuePair<int, string>)roleComboBox.SelectedItem).Key;
            }
        }

        private void deleteUserButton_Click_1(object sender, EventArgs e)
        {
            updateUserStatus(0);
        }

        private void enableUserButton_Click_1(object sender, EventArgs e)
        {
            updateUserStatus(1);
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = usersGridView.SelectedRows[0];
                int roleId = Convert.ToInt32(selectedRow.Cells["role_id"].Value);
                int userId = Convert.ToInt32(selectedRow.Cells["user_id"].Value);

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddUser"))
                {
                    AddUser addUser= new AddUser();
                    addUser.Dock = DockStyle.Fill;
                    Form2.Instance.setAddUser(addUser);
                    addUser.firstname.Text = selectedRow.Cells["firstname"].Value.ToString();
                    addUser.lastname.Text = selectedRow.Cells["lastname"].Value.ToString();
                    addUser.username.Text = selectedRow.Cells["username"].Value.ToString();
                    addUser.phone.Text = selectedRow.Cells["phone"].Value.ToString();
                    addUser.role.SelectedIndex = SelectComboBoxItemByKey(roleId, addUser.role);
                    addUser.setUserId(Convert.ToInt32(selectedRow.Cells["user_id"].Value));
                    addUser.setCurrentUserStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                    addUser.password.Enabled = false;
                    Form2.Instance.PnlContanier.Controls.Add(addUser);
                } else
                {
                    AddUser addUser = Form2.Instance.getAddUser();
                    addUser.firstname.Text = selectedRow.Cells["firstname"].Value.ToString();
                    addUser.lastname.Text = selectedRow.Cells["lastname"].Value.ToString();
                    addUser.username.Text = selectedRow.Cells["username"].Value.ToString();
                    addUser.phone.Text = selectedRow.Cells["phone"].Value.ToString();
                    addUser.role.SelectedIndex = SelectComboBoxItemByKey(roleId, addUser.role);
                    addUser.setUserId(Convert.ToInt32(selectedRow.Cells["user_id"].Value));
                    addUser.setCurrentUserStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                    addUser.password.Enabled = false;
                }
                Form2.Instance.PnlContanier.Controls["AddUser"].BringToFront();
            } else
            {
                MessageBox.Show("Please select a row before editing user.");
            }
        }

        private int SelectComboBoxItemByKey(int key, ComboBox comboBox)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = (KeyValuePair<int, string>)comboBox.Items[i];
                if (item.Key == key)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
