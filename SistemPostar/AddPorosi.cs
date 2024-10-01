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
using ZXing;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.IO.Image;

namespace SistemPostar
{
    public partial class AddPorosi : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public ComboBox clientInput, pikePostareInput, zoneMbulimiInput, orderStatus;
        public NumericUpDown pesha;
        public Label orderNumber, sportelist, status, pikePostare, zoneMbulimi, klient, cmimiPerPeshe, cmimiPrioritet, cmimiTotal, cmimiFatura;
        public PictureBox qrcode;
        public CheckBox priorityCheckBoxInput;
        public Button saveStatus;
        int sportelistId;
        int pikePostareNisjeId = 0;
        int porosiId = 0;
        int PP_CmimiPerPeshe, PP_TarifaPrioritet;
        int total = 0;
        int priority = 0;

        public AddPorosi()
        {
            InitializeComponent();
            PopulateComboBoxes();
            orderStatus = statusForm;
            initializeStatusCombobox(false);
            clientInput = clientComboBox;
            pikePostareInput = pikaPostareComboBox;
            zoneMbulimiInput = zonaMbulimiComboBox;
            pesha = peshaInput;
            orderNumber = orderNumberValue;
            sportelist = sportelistValue;
            status = statusValue;
            pikePostare = pikePostareValue;
            zoneMbulimi = zoneMbulimiValue;
            klient = klientiValue;
            saveStatus = updateStatus;
            saveStatus.Visible = false;
            qrcode = qrCode;
            zoneMbulimiInput.Enabled = false;
            cmimiPerPeshe = cmimiLabel;
            cmimiPrioritet = tarifaPrioritetValue;
            cmimiTotal = totaliLabel;
            cmimiFatura = cmimiReceiptValue;
            priorityCheckBoxInput = priorityCheckBox;
        }

        public void initializeStatusCombobox(bool enabled, int currentStatusIndex = 0)
        {
            orderStatus.Visible = enabled;
            statusInputLabel.Visible = enabled;
            if (enabled)
            {
                orderStatus.SelectedIndex = currentStatusIndex;
            }
        }

        private void setPikePostareNisjeId()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT pike_postare_id FROM Users WHERE user_id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", sportelistId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pikePostareNisjeId = Convert.ToInt32(reader["pike_postare_id"]);
                        }
                    }
                }
            }
        }

        private void PopulateComboBoxes()
        {
            PopulateClientComboBox();
            PopulatePikePostareComboBox();
            PopulateOrderStatusComboBox();
        }

        private void PopulateOrderStatusComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, status_name FROM OrderStatuses", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["status_name"].ToString();

                            statusForm.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            statusForm.DisplayMember = "Value";
            statusForm.ValueMember = "Key";
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

                            clientComboBox.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            clientComboBox.DisplayMember = "Value";
            clientComboBox.ValueMember = "Key";
        }

        public void setTotali(int totali)
        {
            total = totali;
        }

        public void LoadPrices()
        {
            setPikePostareNisjeId();
            setPikePostarePrices();
            cmimiPerPeshe.Text = PP_CmimiPerPeshe.ToString() + " Leke";
            cmimiPrioritet.Text = PP_TarifaPrioritet.ToString() + " Leke";

        }

        private void setPikePostarePrices()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT cmimPesha, tarifePrioritet FROM PikatPostare WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", pikePostareNisjeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PP_CmimiPerPeshe = Convert.ToInt32(reader["cmimPesha"]);
                            PP_TarifaPrioritet = Convert.ToInt32(reader["tarifePrioritet"]);
                        }
                    }
                }
            }
        }

        private void pikaPostareComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pikaPostareComboBox.SelectedIndex != -1)
            {
                zoneMbulimiInput.Items.Clear();
                zoneMbulimiInput.Enabled = true;
                int pikePostareId = ((KeyValuePair<int, string>)pikaPostareComboBox.SelectedItem).Key;
                PopulateZoneMbulimiComboBox(pikePostareId);
            }
        }

        private void saveUserButton_Click(object sender, EventArgs e)
        {
            if (!checkInputs())
            {
                MessageBox.Show("Please fill in all the fields!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "";
            if (porosiId == 0)
            {
                query = "INSERT INTO Orders(id_qytetar, sportelist_id, order_status, pike_postare_id, zone_mbulimi_id, barcode, order_number, is_priority, cmimi, pesha, pike_postare_nisje) VALUES(@id_qytetar, @sportelist_id, @order_status, @pike_postare_id, @zone_mbulimi_id, @barcode, @order_number, @is_priority, @cmimi, @pesha, @pike_postare_nisje)";
                updateOrdersTable(query, false);
            }
            else
            {
                query = "UPDATE Orders SET id_qytetar = @id_qytetar, order_status = @order_status, pike_postare_id = @pike_postare_id, zone_mbulimi_id = @zone_mbulimi_id, is_priority = @is_priority, cmimi = @cmimi, pesha = @pesha, pike_postare_nisje = @pike_postare_nisje, updated_at = @updated_at WHERE id = @id";
                updateOrdersTable(query, true);
            }
        }

        private void updateOrdersTable(string query, bool update)
        {
            try
            {
                int order_number = GetMaxOrderNumber() + 1;
                int orderStatusId = 0;
                string barcode = order_number.ToString() + "" + DateTime.Now.ToShortDateString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_qytetar", ((KeyValuePair<int, string>)clientInput.SelectedItem).Key);
                        command.Parameters.AddWithValue("@pike_postare_id", ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key);
                        command.Parameters.AddWithValue("@zone_mbulimi_id", ((KeyValuePair<int, string>)zoneMbulimiInput.SelectedItem).Key);
                        command.Parameters.AddWithValue("@is_priority", priority);
                        command.Parameters.AddWithValue("@cmimi", total);
                        command.Parameters.AddWithValue("@pesha", peshaInput.Value);
                        command.Parameters.AddWithValue("@pike_postare_nisje", pikePostareNisjeId);

                        if (!update)
                        {
                            command.Parameters.AddWithValue("@order_status", Convert.ToInt32(ConfigurationManager.AppSettings["CreatedOrderStatusId"]));
                            command.Parameters.AddWithValue("@sportelist_id", sportelistId);
                            command.Parameters.AddWithValue("@barcode", barcode);
                            command.Parameters.AddWithValue("@order_number", order_number);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                            command.Parameters.AddWithValue("@id", porosiId);
                            command.Parameters.AddWithValue("@order_status", ((KeyValuePair<int, string>)orderStatus.SelectedItem).Key);
                        }
                        if (command.ExecuteNonQuery() > 0)
                        {
                            orderStatusId = Convert.ToInt32(ConfigurationManager.AppSettings["CreatedOrderStatusId"]);
                            if (update)
                            {
                                orderStatusId = GetOrderStatusById(porosiId);
                                MessageBox.Show("Successfully updated order!");
                            }
                            else
                            {
                                MessageBox.Show("Successfully added order!");
                                NotifyUser(((KeyValuePair<int, string>)clientInput.SelectedItem).Key, order_number);
                            }
                            UpdateReceipt(order_number, sportelistId, orderStatusId, ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Value, ((KeyValuePair<int, string>)zoneMbulimiInput.SelectedItem).Value, ((KeyValuePair<int, string>)clientInput.SelectedItem).Key, barcode, total, peshaInput.Value, priority == 1 ? "Po" : "Jo");
                            FindShortestRoute(pikePostareNisjeId, priority, order_number);
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

        private void NotifyUser(int clientId, int order_number)
        {
            string userEmail = getUserEmail(clientId);
            Mail.sendMail("Posta@Sherbime.al", userEmail, "Porosia juaj u krijua!", "Porosia juaj u krijua.Ju mund ta gjurmoni me kete numer: " + order_number);
        }

        private string getUserEmail(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT email FROM Users WHERE user_id = @user_id", connection))
                {
                    command.Parameters.AddWithValue("@user_id", clientId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            return reader["email"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        public void FindShortestRoute(int pikePostareNisje, int priority, int order_number)
        {
            int starterCityId = 0, destinationCityId = 0, durationLength = 0;
            var graph = new Dictionary<string, Dictionary<string, int>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SElECT * FROM Rruget WHERE is_priority = @is_priority", connection);
                connection.Open();
                command.Parameters.AddWithValue("@is_priority", priority);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    starterCityId = Convert.ToInt32(reader["pike_postare_nisje"]);
                    destinationCityId = Convert.ToInt32(reader["pike_postare_destinacion"]);
                    durationLength = Convert.ToInt32(reader["kohezgjatje"]);
                    string starterCity = starterCityId.ToString();
                    string destinationCity = destinationCityId.ToString();
                    int duration = durationLength;

                    if (!graph.ContainsKey(starterCity))
                    {
                        graph[starterCity] = new Dictionary<string, int>();
                    }

                    // Add destination city and its duration to the start city's dictionary
                    graph[starterCity][destinationCity] = duration;

                    // Add destination city to the graph if not already present
                    if (!graph.ContainsKey(destinationCity))
                    {
                        graph[destinationCity] = new Dictionary<string, int>();
                    }

                    // Add start city and its duration to the destination city's dictionary (for bidirectional graph)
                    graph[destinationCity][starterCity] = duration;

                }
            }

            var shortestRouteFinder = new ShortestRoute(graph);
            var shortestRoute = shortestRouteFinder.FindShortestRoute(pikePostareNisjeId.ToString(), ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key.ToString());

            List<int> shortestPathInt = shortestRoute.Select(int.Parse).ToList();
            int cityToDrop = -1; // Initialize with a default value

            // Start from the end of the shortest path and iterate backward
            for (int i = shortestPathInt.Count - 1; i >= 0; i--)
            {
                int currentCity = shortestPathInt[i];

                // Check if the current city is directly connected to city 5
                if (currentCity != starterCityId && graph.ContainsKey(starterCityId.ToString()) && graph[starterCityId.ToString()].ContainsKey(currentCity.ToString()))
                {
                    cityToDrop = currentCity;
                }
            }

            //add cityToDrop to porosi in database and then change the pako form to add only orders by citytodrop and then update the citytodrop when porosi arrives at the city to be dropeed
            UpdateCityToDropLabel(cityToDrop);
            UpdateCityToDrop(cityToDrop, order_number, pikePostareNisje);
        }

        private void UpdateCityToDropLabel(int cityToDropId)
        {
            string PikePostareToDropLabel = GetPikePostareLabelById(cityToDropId);
            cityToDropLabel.Text = PikePostareToDropLabel;
        }

        private string GetPikePostareLabelById(int pikePostareToDropId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT name FROM PikatPostare WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", pikePostareToDropId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["name"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        private void UpdateCityToDrop(int pikePostareToDrop, int orderNumber, int actualCity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Update Orders Set pike_postare_to_drop = @pike_postare_to_drop, qyteti_aktual = @qyteti_aktual Where order_number = @order_number", connection))
                    {
                        command.Parameters.AddWithValue("@pike_postare_to_drop", pikePostareToDrop);
                        command.Parameters.AddWithValue("@order_number", orderNumber);
                        command.Parameters.AddWithValue("@qyteti_aktual", actualCity);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void peshaInput_ValueChanged(object sender, EventArgs e)
        {
            int pesha = Convert.ToInt32(peshaInput.Value);
            total = pesha * PP_CmimiPerPeshe;
            if (priorityCheckBox.Checked)
            {
                total += PP_TarifaPrioritet;
            }
            cmimiTotal.Text = total.ToString();
        }

        private void priorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (priorityCheckBox.Checked)
            {
                total += getPriorityPrice();
                cmimiTotal.Text = total.ToString();
                priority = 1;
            }
            else
            {
                if (total != 0)
                {
                    total -= getPriorityPrice();
                    cmimiTotal.Text = total.ToString();
                }
                priority = 0;
            }
        }

        private void updateStatus_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update Orders Set order_status = @order_status Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@order_status", ((KeyValuePair<int, string>)orderStatus.SelectedItem).Key);
                    command.Parameters.AddWithValue("@id", porosiId);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Updated successfully");
                        statusValue.Text = ((KeyValuePair<int, string>)orderStatus.SelectedItem).Value;
                        if (((KeyValuePair<int, string>)orderStatus.SelectedItem).Key == Convert.ToInt32(ConfigurationManager.AppSettings["DukeUPaketuar"]))
                        {
                            TrackInfo.addMessage("Porosia eshte duke u paketuar", porosiId);
                        }
                        if (((KeyValuePair<int, string>)orderStatus.SelectedItem).Key == Convert.ToInt32(ConfigurationManager.AppSettings["Paketuar"]))
                        {
                            TrackInfo.addMessage("Porosia u paketua", porosiId);
                        }
                        if (((KeyValuePair<int, string>)orderStatus.SelectedItem).Key == Convert.ToInt32(ConfigurationManager.AppSettings["MberriturNePikePostare"]))
                        {
                            TrackInfo.addMessage("Porosia ka mberritur ne piken postare", porosiId);
                        }
                    } else
                    {
                        MessageBox.Show("Something went wrong!");
                    }
                }
            }
        }

        private void AddPorosi_Load(object sender, EventArgs e)
        {

        }

        private void printoButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Order Number : " + orderNumberValue.Text);
                        writer.WriteLine("Sportelist : " + sportelistValue.Text);
                        writer.WriteLine("Status : " + statusValue.Text);
                        writer.WriteLine("Pike Postare : " + pikePostareValue.Text);
                        writer.WriteLine("Zone Mbulimi : " + zoneMbulimiValue.Text);
                        writer.WriteLine("Klienti : " + klientiValue.Text);
                        writer.WriteLine("Cmimi : " + cmimiFatura.Text);
                        writer.WriteLine("Pesha : " + peshaFature.Text);
                        writer.WriteLine("Prioritet : " + prioritetFatura.Text);
                        writer.WriteLine("Destinacion : " + cityToDropLabel.Text);
                    }

                    MessageBox.Show("Data has been successfully saved to the file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void UpdateReceipt(int order_number, int sportelistId, int orderStatus, string pikePostareName, string zoneMbulimiName, int clientId, string barcode, int cmimi, decimal peshaTekst, string prioritetFaturaTekst)
        {
            if (string.IsNullOrEmpty(orderNumber.Text))
            {
                orderNumber.Text = Convert.ToString(order_number);
            }
            sportelist.Text = GetUsernameById(sportelistId);
            status.Text = GetStatusNameByStatusId(orderStatus);
            pikePostare.Text = pikePostareName;
            zoneMbulimi.Text = zoneMbulimiName;
            klient.Text = GetUsernameById(clientId);
            updateQRCode(barcode);
            cmimiFatura.Text = cmimi.ToString();
            prioritetFatura.Text = prioritetFaturaTekst;
            peshaFature.Text = peshaTekst.ToString() + " kg";
        }

        private void updateQRCode(string content)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODABAR;

            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 258,
                Height = 211,
                Margin = 0
            };

            var barcodeBitmap = barcodeWriter.Write(content);

            qrcode.BackgroundImage = barcodeBitmap;
        }

        private string GetUsernameById(int sportelistId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Username FROM Users WHERE user_id = @user_id", connection))
                {
                    command.Parameters.AddWithValue("@user_id", sportelistId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Username"].ToString();
                        } else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        private string GetStatusNameByStatusId(int orderStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT status_name FROM OrderStatuses WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderStatus);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["status_name"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        private int GetOrderStatusById(int porosiId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT order_status FROM Orders WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", porosiId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["order_status"]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        private int GetMaxOrderNumber()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(MAX(order_number), 0) FROM Orders";
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void clearInputs()
        {
            clientInput.SelectedIndex = -1;
            pikePostareInput.SelectedIndex = -1;
            zoneMbulimiInput.SelectedIndex = -1;
            zoneMbulimiInput.Enabled = false;
            orderNumber.Text = string.Empty;
            sportelist.Text = string.Empty;
            status.Text = string.Empty;
            pikePostare.Text = string.Empty;
            zoneMbulimi.Text = string.Empty;
            klient.Text = string.Empty;
            qrcode.BackgroundImage = null;
            cmimiFatura.Text = "";
            cmimiTotal.Text = "";
            peshaInput.Value = 0;
            priorityCheckBox.Checked = false;
            priority = 0;
            prioritetFatura.Text = "";
            peshaFature.Text = "";
        }

        public void setPorosiId(int porosi_id)
        {
            porosiId = porosi_id;
        }

        public void setSportelistId(int id)
        {
            sportelistId = id;
        }

        private bool checkInputs()
        {
            if (clientInput.SelectedIndex == -1)
            {
                return false;
            }
            if (pikePostareInput.SelectedIndex == -1)
            {
                return false;
            }
            if (zoneMbulimiInput.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            clearInputs();
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

                            pikaPostareComboBox.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            pikaPostareComboBox.DisplayMember = "Value";
            pikaPostareComboBox.ValueMember = "Key";
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

                            zoneMbulimiInput.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            zoneMbulimiInput.DisplayMember = "Value";
            zoneMbulimiInput.ValueMember = "Key";
        }

        private int getPriorityPrice()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM Rruget WHERE pike_postare_nisje = @pike_postare_nisje AND pike_postare_destinacion = @destinacionId", connection))
                {
                    command.Parameters.AddWithValue("@pike_postare_nisje", pikePostareNisjeId);
                    command.Parameters.AddWithValue("@destinacionId", ((KeyValuePair<int, string>)pikaPostareComboBox.SelectedItem).Key);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PP_CmimiPerPeshe = 40;
                            int kohezgjatje = Convert.ToInt32(reader["kohezgjatje"]);
                            return kohezgjatje * PP_CmimiPerPeshe;
                        }
                        return 0;
                    }
                }
            }
        }

    }
}





