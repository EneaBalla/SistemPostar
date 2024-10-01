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
    public partial class PikaPostareList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string roleQuery = "";

        public PikaPostareList()
        {
            InitializeComponent();
        }

        private void updatePikePostareStatus(int newStatus)
        {
            try
            {
                if (pikaPostareGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = pikaPostareGridView.SelectedRows[0];
                    DialogResult result = MessageBox.Show("Update pike postare?", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int id= Convert.ToInt32(selectedRow.Cells["id"].Value);
                        string deleteQuery = "UPDATE PikatPostare SET status = @status WHERE id = @id";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                command.Parameters.AddWithValue("@status", newStatus);
                                command.Parameters.AddWithValue("@id", id);
                                if (command.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Successfully updated pike postare!");
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
                    MessageBox.Show("Please select a row before updating pike postare.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void showPikaPostare_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM PikatPostare WHERE 1 = 1";
                if (!string.IsNullOrEmpty(namePikePostareForm.Text.Trim()))
                {
                    selectQuery += " AND name LIKE @name";
                }
                if (!string.IsNullOrEmpty(addressPikePostareForm.Text.Trim()))
                {
                    selectQuery += " AND address LIKE @address";
                }
                if (!string.IsNullOrEmpty(cityPikePostareForm.Text.Trim()))
                {
                    selectQuery += " AND city LIKE @city";
                }
                if (!string.IsNullOrEmpty(numerPostarForm.Text.Trim()))
                {
                    selectQuery += " AND numer_postar LIKE @numer_postar";
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + namePikePostareForm.Text + "%");
                    command.Parameters.AddWithValue("@address", "%" + addressPikePostareForm.Text + "%");
                    command.Parameters.AddWithValue("@city", "%" + cityPikePostareForm.Text + "%");
                    command.Parameters.AddWithValue("@numer_postar", "%" + numerPostarForm.Text + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            pikaPostareGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        pikaPostareGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void clearPikaPostareList_Click(object sender, EventArgs e)
        {
            cityPikePostareForm.Text = string.Empty;
            addressPikePostareForm.Text = string.Empty;
            numerPostarForm.Text = string.Empty;
            namePikePostareForm.Text = string.Empty;
            roleQuery = "";
        }

        private void deletePikePostareButton_Click(object sender, EventArgs e)
        {
            updatePikePostareStatus(0);
        }

        private void enablePikePostareButton_Click(object sender, EventArgs e)
        {
            updatePikePostareStatus(1);
        }

        private void editPikePostareButton_Click(object sender, EventArgs e)
        {
            if (pikaPostareGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = pikaPostareGridView.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddPikaPostare"))
                {
                    AddPikaPostare addPikaPostare = new AddPikaPostare();
                    addPikaPostare.Dock = DockStyle.Fill;
                    Form2.Instance.setAddPikaPostare(addPikaPostare);
                    addPikaPostare.clearInputs();
                    addPikaPostare.name.Text = selectedRow.Cells["name"].Value.ToString();
                    addPikaPostare.city.Text = selectedRow.Cells["city"].Value.ToString();
                    addPikaPostare.address.Text = selectedRow.Cells["address"].Value.ToString();
                    addPikaPostare.numerPostar.Text = selectedRow.Cells["numer_postar"].Value.ToString();
                    addPikaPostare.cmimiPeshe.Value = Convert.ToInt32(selectedRow.Cells["cmimPesha"].Value);
                    addPikaPostare.tarifaPrioritet.Value = Convert.ToInt32(selectedRow.Cells["tarifePrioritet"].Value);
                    addPikaPostare.setPikePostareId(Convert.ToInt32(selectedRow.Cells["id"].Value));
                    addPikaPostare.setCurrentPikePostareStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                    Form2.Instance.PnlContanier.Controls.Add(addPikaPostare);
                }
                else
                {
                    AddPikaPostare addPikaPostare = Form2.Instance.getAddPikaPostare();
                    addPikaPostare.clearInputs();
                    addPikaPostare.name.Text = selectedRow.Cells["name"].Value.ToString();
                    addPikaPostare.city.Text = selectedRow.Cells["city"].Value.ToString();
                    addPikaPostare.address.Text = selectedRow.Cells["address"].Value.ToString();
                    addPikaPostare.numerPostar.Text = selectedRow.Cells["numer_postar"].Value.ToString();
                    addPikaPostare.cmimiPeshe.Value = Convert.ToInt32(selectedRow.Cells["cmimPesha"].Value);
                    addPikaPostare.tarifaPrioritet.Value = Convert.ToInt32(selectedRow.Cells["tarifePrioritet"].Value);
                    addPikaPostare.setPikePostareId(Convert.ToInt32(selectedRow.Cells["id"].Value));
                    addPikaPostare.setCurrentPikePostareStatus(Convert.ToInt32(selectedRow.Cells["status"].Value));
                }
                Form2.Instance.PnlContanier.Controls["AddPikaPostare"].BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a row before editing pike postare.");
            }
        }

        private void rrugetButon_Click(object sender, EventArgs e)
        {
            if (pikaPostareGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = pikaPostareGridView.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                AddRruge addRruge;
                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddRruge"))
                {
                    addRruge = new AddRruge();
                    addRruge.Dock = DockStyle.Fill;
                    Form2.Instance.setAddRruge(addRruge);
                    Form2.Instance.PnlContanier.Controls.Add(addRruge);
                }
                else
                {
                    addRruge = Form2.Instance.getAddRruge();
                }
                addRruge.pikePostareNisjeInput.Text = selectedRow.Cells["name"].Value.ToString();
                addRruge.InitializeRrugeForm(Convert.ToInt32(selectedRow.Cells["id"].Value));
                Form2.Instance.PnlContanier.Controls["AddRruge"].BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }
    }
}
