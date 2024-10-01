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
    public partial class PorosiList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string pikePostareQuery = "";
        string klientQuery = "";
        string zoneMbulimiQuery = "";
        int klientId = 0;
        int zoneMbulimiId = 0;
        int pikePostareId = 0;
        int sportelistId = 0;

        public PorosiList()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            PopulateClientComboBox();
            PopulatePikePostareComboBox();
        }

        private void PopulateClientComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT user_id, Username FROM Users WHERE status = 1 AND role_id = @role_id", connection))
                {
                    command.Parameters.AddWithValue("@role_id", ConfigurationManager.AppSettings["KlientId"]);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["user_id"]);
                            string roleName = reader["Username"].ToString();

                            klientForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            klientForm.DisplayMember = "Value";
            klientForm.ValueMember = "Key";
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

                            pikePostareForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            pikePostareForm.DisplayMember = "Value";
            pikePostareForm.ValueMember = "Key";
        }

        private void pikePostareForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikePostareForm.SelectedIndex != -1)
            {
                zonaMbulimiForm.Enabled = true;
                zonaMbulimiForm.Items.Clear();
                pikePostareQuery += " AND pike_postare_id = @pike_postare_id";
                pikePostareId = ((KeyValuePair<int, string>)pikePostareForm.SelectedItem).Key;
                PopulateZoneMbulimiComboBox(pikePostareId);
            }
        }

        private void PopulateZoneMbulimiComboBox(int pikePostareId)
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

                            zonaMbulimiForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            zonaMbulimiForm.DisplayMember = "Value";
            zonaMbulimiForm.ValueMember = "Key";
        }

        private void clearZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            klientForm.SelectedIndex = -1;
            pikePostareForm.SelectedIndex = -1;
            zonaMbulimiForm.SelectedIndex = -1;
            zonaMbulimiForm.Enabled = false;
            klientQuery = "";
            pikePostareQuery = "";
            zoneMbulimiQuery = "";
            porosiGridView.DataSource = null;
        }

        private void showPorosiButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Orders WHERE sportelist_id = @sportelist_id";
                if (klientId != 0)
                {
                    selectQuery += klientQuery;
                }
                if (pikePostareId != 0)
                {
                    selectQuery += pikePostareQuery;
                }
                if (zoneMbulimiId != 0)
                {
                    selectQuery += zoneMbulimiQuery;
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@sportelist_id", sportelistId);
                    command.Parameters.AddWithValue("@id_qytetar", klientId);
                    command.Parameters.AddWithValue("@pike_postare_id", pikePostareId);
                    command.Parameters.AddWithValue("@zone_mbulimi_id", zoneMbulimiId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            porosiGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        porosiGridView.DataSource = dataTable;
                    }
                }
            }
        }

        public void setSportelistId(int id)
        {
            sportelistId = id;
        }

        private void klientForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (klientForm.SelectedIndex != -1)
            {
                klientQuery = " AND id_qytetar = @id_qytetar";
                klientId = ((KeyValuePair<int, string>)klientForm.SelectedItem).Key;
            }
        }

        private void zonaMbulimiForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zonaMbulimiForm.SelectedIndex != -1)
            {
                zoneMbulimiQuery = " AND zone_mbulimi_id = @zone_mbulimi_id";
                zoneMbulimiId = ((KeyValuePair<int, string>)zonaMbulimiForm.SelectedItem).Key;
            }
        }

        private void enablePorosiButton_Click(object sender, EventArgs e)
        {
        }

        private void deletePorosiButton_Click(object sender, EventArgs e)
        {
        }

        private void editPorosiButton_Click(object sender, EventArgs e)
        {
            if (porosiGridView.SelectedRows.Count > 0)
            {
                AddPorosi addPorosi;
                DataGridViewRow selectedRow = porosiGridView.SelectedRows[0];
                int porosiId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                int clientId = Convert.ToInt32(selectedRow.Cells["id_qytetar"].Value);
                int pikePostareId = Convert.ToInt32(selectedRow.Cells["pike_postare_id"].Value);
                int zoneMbulimiId = Convert.ToInt32(selectedRow.Cells["zone_mbulimi_id"].Value);
                int orderNumber = Convert.ToInt32(selectedRow.Cells["order_number"].Value);
                int sportelistId = Convert.ToInt32(selectedRow.Cells["sportelist_id"].Value);
                int order_status = Convert.ToInt32(selectedRow.Cells["order_status"].Value);
                int cmimi = Convert.ToInt32(selectedRow.Cells["cmimi"].Value);
                decimal pesha = Convert.ToDecimal(selectedRow.Cells["pesha"].Value);
                int isPriority = Convert.ToInt32(selectedRow.Cells["is_priority"].Value);
                int pikePostareNisjeId = Convert.ToInt32(selectedRow.Cells["pike_postare_nisje"].Value);

                string barcode = selectedRow.Cells["barcode"].Value.ToString();

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddPorosi"))
                {
                    addPorosi = new AddPorosi();
                    addPorosi.Dock = DockStyle.Fill;
                    Form2.Instance.setAddPorosi(addPorosi);
                    
                    Form2.Instance.PnlContanier.Controls.Add(addPorosi);
                }
                else
                {
                    addPorosi = Form2.Instance.getAddPorosi();
                }
                addPorosi.setPorosiId(porosiId);
                addPorosi.setSportelistId(Form2.Instance.getUserId());
                addPorosi.clearInputs();
                addPorosi.LoadPrices();
                addPorosi.initializeStatusCombobox(true, SelectComboBoxItemByKey(order_status, addPorosi.orderStatus));
                addPorosi.clientInput.SelectedIndex = SelectComboBoxItemByKey(clientId, addPorosi.clientInput);
                addPorosi.pikePostareInput.SelectedIndex = SelectComboBoxItemByKey(pikePostareId, addPorosi.pikePostareInput);
                addPorosi.zoneMbulimiInput.SelectedIndex = SelectComboBoxItemByKey(zoneMbulimiId, addPorosi.zoneMbulimiInput);
                addPorosi.UpdateReceipt(orderNumber, sportelistId, order_status, addPorosi.pikePostareInput.Text, addPorosi.zoneMbulimiInput.Text, clientId, barcode, cmimi, pesha, isPriority == 1 ? "Po" : "Jo");
                addPorosi.saveStatus.Visible = true;
                if (isPriority == 1) 
                {
                    addPorosi.priorityCheckBoxInput.Checked = true;
                }
                addPorosi.pesha.Value = pesha;
                addPorosi.cmimiTotal.Text = cmimi.ToString();
                addPorosi.setTotali(cmimi);
                Form2.Instance.PnlContanier.Controls["AddPorosi"].BringToFront();
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
