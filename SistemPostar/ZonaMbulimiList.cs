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
    public partial class ZonaMbulimiList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string pikePostareQuery = "";
        int pikePostareId = 0;

        public ZonaMbulimiList()
        {
            InitializeComponent();
            PopulatePikePostareComboBox();
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

                            pikaPostareForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            pikaPostareForm.DisplayMember = "Value";
            pikaPostareForm.ValueMember = "Key";
        }

        private void updateZonaMbulimiStatus(int newStatus)
        {
            try
            {
                if (zonaMbulimiGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = zonaMbulimiGridView.SelectedRows[0];
                    DialogResult result = MessageBox.Show("Update zone mbulimi?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int zoneMbulimiId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        string deleteQuery = "UPDATE ZonaMbulimi SET status = @status WHERE id = @id";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@status", newStatus);
                                command.Parameters.AddWithValue("@id", zoneMbulimiId);
                                if (command.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Successfully updated zone mbulimi!");
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
                    MessageBox.Show("Please select a row before updating zone mbulimi.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void clearZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            nameSearchBox.Text = string.Empty;
            pikaPostareForm.SelectedIndex = -1;
            pikePostareId = 0;
            pikePostareQuery = "";
        }

        private void showZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM ZonaMbulimi WHERE 1 = 1";
                if (!string.IsNullOrEmpty(nameSearchBox.Text.Trim()))
                {
                    selectQuery += " AND name LIKE @name";
                }
                if (pikePostareId != 0)
                {
                    selectQuery += pikePostareQuery;
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + nameSearchBox.Text + "%");
                    command.Parameters.AddWithValue("@pike_postare_id", pikePostareId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            zonaMbulimiGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        zonaMbulimiGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void pikaPostareForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikaPostareForm.SelectedIndex != -1)
            {
                pikePostareQuery = " AND pike_postare_id = @pike_postare_id";
                pikePostareId = ((KeyValuePair<int, string>)pikaPostareForm.SelectedItem).Key;
            }
        }

        private void enableZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            updateZonaMbulimiStatus(1);
        }

        private void deleteZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            updateZonaMbulimiStatus(0);
        }

        private void editZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            if (zonaMbulimiGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = zonaMbulimiGridView.SelectedRows[0];
                int pikePostareId = Convert.ToInt32(selectedRow.Cells["pike_postare_id"].Value);
                int zoneMbulimiId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddZonaMbulimi"))
                {
                    AddZonaMbulimi addZonaMbulimi = new AddZonaMbulimi();
                    addZonaMbulimi.Dock = DockStyle.Fill;
                    Form2.Instance.setAddZonaMbulimi(addZonaMbulimi);
                    addZonaMbulimi.name.Text = selectedRow.Cells["name"].Value.ToString();
                    addZonaMbulimi.pikaPostare.SelectedIndex = SelectComboBoxItemByKey(pikePostareId, addZonaMbulimi.pikaPostare);
                    addZonaMbulimi.setZonaMbulimiId(Convert.ToInt32(selectedRow.Cells["id"].Value));
                    addZonaMbulimi.setCurrentZonaMbulimiStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                    Form2.Instance.PnlContanier.Controls.Add(addZonaMbulimi);
                }
                else
                {
                    AddZonaMbulimi addZonaMbulimi = Form2.Instance.getAddZonaMbulimi();
                    addZonaMbulimi.name.Text = selectedRow.Cells["name"].Value.ToString();
                    addZonaMbulimi.pikaPostare.SelectedIndex = SelectComboBoxItemByKey(pikePostareId, addZonaMbulimi.pikaPostare);
                    addZonaMbulimi.setZonaMbulimiId(Convert.ToInt32(selectedRow.Cells["id"].Value));
                    addZonaMbulimi.setCurrentZonaMbulimiStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                }
                Form2.Instance.PnlContanier.Controls["AddZonaMbulimi"].BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a row before editing zone mbulimi.");
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
