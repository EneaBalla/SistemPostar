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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemPostar
{
    public partial class AddZonaMbulimi : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public TextBox name;
        public ComboBox pikaPostare;
        int zonaMbulimiId = 0;
        int currentZonaMbulimiStatus = 0;

        public AddZonaMbulimi()
        {
            InitializeComponent();
            PopulatePikaPostareComboBox();
            name = nameForm;
            pikaPostare = pikePostareForm;
        }

        private void PopulatePikaPostareComboBox()
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

                            pikePostareForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            pikePostareForm.DisplayMember = "Value";
            pikePostareForm.ValueMember = "Key";
        }

        public void clearInputs()
        {
            name.Text = string.Empty;
            pikaPostare.SelectedIndex = -1;
        }

        public void setZonaMbulimiId(int user_id)
        {
            zonaMbulimiId = user_id;
        }

        public void setCurrentZonaMbulimiStatus(int status)
        {
            currentZonaMbulimiStatus = status;
        }

        private void saveUserButton_Click(object sender, EventArgs e)
        {
            bool isUpdate = true;
            if (!checkInputs())
            {
                MessageBox.Show("Please fill in all the fields!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "";
            if (zonaMbulimiId == 0)
            {
                query = "INSERT INTO ZonaMbulimi(name, pike_postare_id, status) VALUES(@name, @pike_postare_id, @status)";
                updateZonaMbulimiTable(query, false);
            }
            else
            {
                query = "UPDATE ZonaMbulimi SET name = @name, pike_postare_id = @pike_postare_id, status = @status, updated_at = @updated_at WHERE id = @id";
                updateZonaMbulimiTable(query, true);
            }
        }

        private bool checkInputs()
        {
            if (string.IsNullOrEmpty(name.Text.Trim()))
            {
                return false;
            }
            if (pikePostareForm.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void updateZonaMbulimiTable(string query, bool update)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name.Text);
                        command.Parameters.AddWithValue("@pike_postare_id", ((KeyValuePair<int, string>)pikaPostare.SelectedItem).Key);
                        command.Parameters.AddWithValue("@status", currentZonaMbulimiStatus);
                        if (update)
                        {
                            command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                            command.Parameters.AddWithValue("@id", zonaMbulimiId);
                        }
                        if (command.ExecuteNonQuery() > 0)
                        {
                            if (update)
                            {
                                MessageBox.Show("Successfully updated zone mbulimi!");
                            }
                            else
                            {
                                MessageBox.Show("Successfully added zone mbulimi!");
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
    }
}
