using System;
using System.Collections;
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
    public partial class AddRruge : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Label pikePostareNisjeInput;
        int pikePostareNisjeId;
        public AddRruge()
        {
            InitializeComponent();
            pikePostareNisjeInput = pikePostareNisjeLabel;
        }

        public void InitializeRrugeForm(int id)
        {
            setPikePostareNisjeId(id);
            destinacionComboBox.Items.Clear();
            PopulatePikePostareDestinacionComboBox();
        }

        private void setPikePostareNisjeId(int id)
        {
            pikePostareNisjeId = id;
        }

        public void PopulatePikePostareDestinacionComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name FROM PikatPostare", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            if (id == pikePostareNisjeId)
                            {
                                continue;
                            }
                            string name = reader["name"].ToString();

                            destinacionComboBox.Items.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }

            destinacionComboBox.DisplayMember = "Value";
            destinacionComboBox.ValueMember = "Key";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!checkInputs())
            {
                MessageBox.Show("Make sure all the neccessary fields are not empty!");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Rruget(pike_postare_nisje, pike_postare_destinacion, kohezgjatje, rruga, is_priority) Values (@pike_postare_nisje, @pike_postare_destinacion, @kohezgjatje, @rruga, @is_priority)", connection))
                    {
                        int isChecked = 0;
                        if (priorityCheckBox.Checked)
                        {
                            isChecked = 1;
                        }
                        command.Parameters.AddWithValue("@pike_postare_nisje", pikePostareNisjeId);
                        command.Parameters.AddWithValue("@pike_postare_destinacion", ((KeyValuePair<int, string>)destinacionComboBox.SelectedItem).Key);
                        command.Parameters.AddWithValue("@kohezgjatje", kohezgjatjeField.Value);
                        command.Parameters.AddWithValue("@rruga", rrugaTextBox.Text);
                        command.Parameters.AddWithValue("@is_priority", isChecked);
                        
                        if (command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully added rruge!");
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
            destinacionComboBox.SelectedIndex = -1;
            rrugaTextBox.Text = string.Empty;
            kohezgjatjeField.Value = 0;
            priorityCheckBox.Checked = false;
        }

        private bool checkInputs()
        {
            if (destinacionComboBox.SelectedIndex == -1)
            {
                return false;
            }
            if (kohezgjatjeField.Value <= 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(rrugaTextBox.Text))
            {
                return false;
            }
            return true;
        }

    }
}
