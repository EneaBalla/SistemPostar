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
    public partial class ShperndaresList : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        int shperndaresId, pikePostareShperndares, zoneMbulimiShperndares;
        int prioritet = 0;
        public ShperndaresList(int shperndares_id)
        {
            InitializeComponent();
            setShperndaresId(shperndares_id);
            getShperndaresDetails();
        }

        public void getShperndaresDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT pike_postare_id, zone_mbulimi_id FROM Users WHERE user_id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", shperndaresId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pikePostareShperndares = Convert.ToInt32(reader["pike_postare_id"]);
                            zoneMbulimiShperndares = Convert.ToInt32(reader["zone_mbulimi_id"]);
                        }
                    }
                }
            }
        }

        public void setShperndaresId(int id)
        {
            shperndaresId = id;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shperndaresGridView.DataSource = null;
            prioritetCheckBoxInput.Checked = false;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (shperndaresGridView.SelectedRows.Count > 0)
            {
                ViewPorosi viewPorosi;
                DataGridViewRow selectedRow = shperndaresGridView.SelectedRows[0];
                int porosiId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                int clientId = Convert.ToInt32(selectedRow.Cells["id_qytetar"].Value);
                int pikePostareId = Convert.ToInt32(selectedRow.Cells["pike_postare_id"].Value);
                int zoneMbulimiId = Convert.ToInt32(selectedRow.Cells["zone_mbulimi_id"].Value);
                int orderNumber = Convert.ToInt32(selectedRow.Cells["order_number"].Value);
                int sportelistId = Convert.ToInt32(selectedRow.Cells["sportelist_id"].Value);
                int order_status = Convert.ToInt32(selectedRow.Cells["order_status"].Value);
                string barcode = selectedRow.Cells["barcode"].Value.ToString();

                if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ViewPorosi"))
                {
                    viewPorosi = new ViewPorosi();
                    viewPorosi.Dock = DockStyle.Fill;
                    Form2.Instance.setViewPorosi(viewPorosi);

                    Form2.Instance.PnlContanier.Controls.Add(viewPorosi);
                }
                else
                {
                    viewPorosi = Form2.Instance.getViewPorosi();
                }
                viewPorosi.clearStatusComboBox();
                viewPorosi.setPorosiId(porosiId);
                viewPorosi.initializeStatusCombobox();
                viewPorosi.statusInput.SelectedIndex = SelectComboBoxItemByKey(order_status, viewPorosi.statusInput);
                viewPorosi.updateReceipt(orderNumber, sportelistId, pikePostareId, zoneMbulimiId, clientId, barcode);
                Form2.Instance.PnlContanier.Controls["ViewPorosi"].BringToFront();
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

        private void prioritetCheckBoxInput_CheckedChanged(object sender, EventArgs e)
        {
            prioritet = 1;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // add priority to select
                string selectQuery = "SELECT * FROM Orders WHERE pike_postare_id = @pike_postare_id AND zone_mbulimi_id = @zone_mbulimi_id AND order_status = @order_status";
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@pike_postare_id", pikePostareShperndares);
                    command.Parameters.AddWithValue("@zone_mbulimi_id", zoneMbulimiShperndares);
                    command.Parameters.AddWithValue("@order_status", Convert.ToInt32(ConfigurationManager.AppSettings["OrderReadyForShperndares"]));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            shperndaresGridView.DataSource = null;
                            MessageBox.Show("No records found.");
                            return;
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        shperndaresGridView.DataSource = dataTable;
                    }
                }
            }
        }
    }
}
