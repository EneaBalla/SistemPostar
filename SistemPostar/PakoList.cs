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
    public partial class PakoList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string pikePostareNisjeQuery = "";
        string pikePostareMberritjeQuery = "";
        string statusQuery = "";
        string kohezgjatjeQuery = "";
        int pikeNisjeId = 0;
        int pikeMberritjeId = 0;
        int statusId = 0;
        string kohezgjatja = "";
        int transportuesId = 0;

        public PakoList()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        public void setTransportuesId(int transportues_id)
        {
            transportuesId = transportues_id;
        }

        private void PopulateComboBoxes()
        {
            PopulatePikatPostareComboBoxes();
            PopulatePakoStatusesComboBox();
            PopulateKohezgjatjaComboBox();
        }

        private void PopulatePikatPostareComboBoxes()
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
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString();

                            pikaNisjeForm.Items.Add(new KeyValuePair<int, string>(id, name));
                            pikaMberritjesForm.Items.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }

            pikaNisjeForm.DisplayMember = "Value";
            pikaNisjeForm.ValueMember = "Key";

            pikaMberritjesForm.DisplayMember = "Value";
            pikaMberritjesForm.ValueMember = "Key";
        }

        private void PopulatePakoStatusesComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, status_name FROM PakoStatuses", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["status_name"].ToString();

                            pakoStatusForm.Items.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }

            pakoStatusForm.DisplayMember = "Value";
            pakoStatusForm.ValueMember = "Key";
        }

        private void PopulateKohezgjatjaComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT kohezgjatja FROM Pakot WHERE kohezgjatja IS NOT NULL AND kohezgjatja <> ''";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string duration = reader["kohezgjatja"].ToString();

                                kohezgjataForm.Items.Add(new KeyValuePair<string, string>(duration, duration));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No distinct durations found.");
                        }
                    }
                }
            }

            kohezgjataForm.DisplayMember = "Value";
            kohezgjataForm.ValueMember = "Key";
        }

        private void pikaNisjeForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikaNisjeForm.SelectedIndex != -1)
            {
                pikePostareNisjeQuery = " AND pika_postare_nisje = @pika_postare_nisje";
                pikeNisjeId = ((KeyValuePair<int, string>)pikaNisjeForm.SelectedItem).Key;
            }
        }

        private void pikaMberritjesForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikaMberritjesForm.SelectedIndex != -1)
            {
                pikePostareMberritjeQuery = " AND pike_postare_id = @pike_postare_id";
                pikeMberritjeId = ((KeyValuePair<int, string>)pikaMberritjesForm.SelectedItem).Key;
            }
        }

        private void pakoStatusForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pakoStatusForm.SelectedIndex != -1)
            {
                statusQuery = " AND status_dergesa = @status_dergesa";
                statusId = ((KeyValuePair<int, string>)pakoStatusForm.SelectedItem).Key;
            }
        }

        private void kohezgjataForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kohezgjataForm.SelectedIndex != -1)
            {
                kohezgjatjeQuery = " AND kohezgjatja LIKE @kohezgjatja";
                kohezgjatja = ((KeyValuePair<string, string>)kohezgjataForm.SelectedItem).Key;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Pakot WHERE created_by = @transportues_id";
                if (pikeNisjeId != 0)
                {
                    selectQuery += pikePostareNisjeQuery;
                }
                if (pikeMberritjeId != 0)
                {
                    selectQuery += pikePostareMberritjeQuery;
                }
                if (statusId != 0)
                {
                    selectQuery += statusQuery;
                }
                if (!string.IsNullOrEmpty(kohezgjatja))
                {
                    selectQuery += kohezgjatjeQuery;
                }
                if (!string.IsNullOrEmpty(pakoNumberForm.Text.Trim()))
                {
                    selectQuery += " AND pako_number LIKE @pako_number";
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@transportues_id", transportuesId);
                    command.Parameters.AddWithValue("@pika_postare_nisje", pikeNisjeId);
                    command.Parameters.AddWithValue("@pike_postare_id", pikeMberritjeId);
                    command.Parameters.AddWithValue("@status_dergesa", statusId);
                    command.Parameters.AddWithValue("@kohezgjatja", "%"+ kohezgjatja + "%");
                    command.Parameters.AddWithValue("@pako_number", "%" + pakoNumberForm.Text + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            pakoGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        pakoGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearInputs();
        }

        public void clearInputs()
        {
            pakoGridView.DataSource = null;
            pikaMberritjesForm.SelectedIndex = -1;
            pikaNisjeForm.SelectedIndex = -1;
            pakoStatusForm.SelectedIndex = -1;
            kohezgjataForm.SelectedIndex = -1;
            pakoNumberForm.Text = string.Empty;
            pikePostareMberritjeQuery = "";
            pikePostareNisjeQuery = "";
            kohezgjatjeQuery = "";
            statusQuery = "";
            pikeNisjeId = 0;
            pikeMberritjeId = 0;
            statusId = 0;
            kohezgjatja = "";
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (pakoGridView.SelectedRows.Count > 0)
            {
                ViewPako viewPako;
                DataGridViewRow selectedRow = pakoGridView.SelectedRows[0];
                int pakoId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string pakoNumber = selectedRow.Cells["pako_number"].Value.ToString();
                string barcode = selectedRow.Cells["barcode"].Value.ToString();
                int pakoStatus = Convert.ToInt32(selectedRow.Cells["status_dergesa"].Value);
                int pikePostareNisje = Convert.ToInt32(selectedRow.Cells["pika_postare_nisje"].Value);
                int pikePostareMberritje = Convert.ToInt32(selectedRow.Cells["pike_postare_id"].Value);
                int createdBy = Convert.ToInt32(selectedRow.Cells["created_by"].Value);
                string kohezgjatja = selectedRow.Cells["kohezgjatja"].Value.ToString();

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ViewPako"))
                {
                    viewPako = new ViewPako();
                    viewPako.Dock = DockStyle.Fill;
                    Form2.Instance.setViewPako(viewPako);

                    Form2.Instance.PnlContanier.Controls.Add(viewPako);
                }
                else
                {
                    viewPako = Form2.Instance.getViewPako();
                }
                viewPako.setPakoId(pakoId);
                viewPako.displayPorosi();
                viewPako.pakoStatusInput.SelectedIndex = SelectComboBoxItemByKey(pakoStatus, viewPako.pakoStatusInput);
                viewPako.UpdateDetails(pakoNumber, createdBy, pakoStatus, pikePostareNisje, pikePostareMberritje, kohezgjatja, barcode);
                Form2.Instance.PnlContanier.Controls["ViewPako"].BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a row.");
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
