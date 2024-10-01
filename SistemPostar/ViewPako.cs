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
using ZXing;
using static SistemPostar.AddPako;

namespace SistemPostar
{
    public partial class ViewPako : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public ComboBox pakoStatusInput;
        public ListBox porosiInput, pakoOutput;
        string statusQuery = "";
        int statusId = 0;
        int pakoId = 0;

        public ViewPako()
        {
            InitializeComponent();
            pakoStatusInput = pakoStatusComboBox;
            PopulatePakoStatusComboBox();
        }

        public class PorosiItem
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Value;
            }

            public int getKey()
            {
                return Key;
            }

            public string getValue()
            {
                return Value;
            }
        }

        public void UpdateDetails(string pako_number, int transportuesId, int statusId, int pikePostareNisjeId, int pikePostareMberritjeId, string kohezgjatje, string barcode)
        {
            pakoNumberValue.Text = pako_number;
            transportuesValue.Text = getTransportuesUsernameById(transportuesId);
            pikePostareNisjeValue.Text = getPikePostareNameById(pikePostareNisjeId);
            pikePostareMberritjeValue.Text = getPikePostareNameById(pikePostareMberritjeId);
            koheZgjatjaValue.Text = kohezgjatje;
            updateBarcode(barcode);
        }

        public void displayPorosi()
        {
            porosiListBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, order_number FROM Orders WHERE pako_id = @pako_id", connection))
                {
                    command.Parameters.AddWithValue("@pako_id", pakoId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string label = "Order: " + reader["order_number"].ToString();

                            PorosiItem pItem = new PorosiItem { Key = id, Value = label };
                            porosiListBox.Items.Add(pItem);
                        }
                    }
                }
            }
        }

        private void updateBarcode(string content)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODABAR;

            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 258,
                Height = 211,
                Margin = 0
            };

            var barcodeBitmap = barcodeWriter.Write(content.Trim());

            barCode.BackgroundImage = barcodeBitmap;
        }

        private string getPikePostareNameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT name FROM PikatPostare WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
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

        private string getTransportuesUsernameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE user_id = @user_id", connection))
                {
                    command.Parameters.AddWithValue("@user_id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["username"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        public void PopulatePakoStatusComboBox()
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

                            pakoStatusInput.Items.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }

            pakoStatusInput.DisplayMember = "Value";
            pakoStatusInput.ValueMember = "Key";
        }

        private void pakoStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pakoStatusComboBox.SelectedIndex != -1) 
            {
                statusQuery = "status_dergesa = @status_dergesa";
                statusId = ((KeyValuePair<int, string>)pakoStatusComboBox.SelectedItem).Key;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusId != 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("UPDATE Pakot SET " + statusQuery + ",updated_at = @updated_at WHERE id = @id", connection))
                        {
                            command.Parameters.AddWithValue("@id", pakoId);
                            command.Parameters.AddWithValue("@status_dergesa", statusId);
                            command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                            if (command.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Successfully updated status!");
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong");
                            }
                        }
                    }
                    if (statusId == Convert.ToInt32(ConfigurationManager.AppSettings["PakoMberritur"]))
                    {
                        bool sendMail = false;
                        int pakoDuration = getPakoKohezgjatje(pakoId);
                        DateTime createdAt = getPakoCreatedAt(pakoId);

                        TimeSpan difference = DateTime.Now - createdAt;
                        int daysPassed = (int)difference.TotalDays;
                        if (daysPassed > (pakoDuration * 2))
                        {
                            sendMail = true;
                        }
                        foreach (PorosiItem pItem in porosiListBox.Items)
                        {
                            int isOrderTranist = checkIfOrderIsTransit(pItem.Key);
                            UpdateQytetiAktual(pItem.Key);
                            int qytetiAktual = getQytetAktual(pItem.Key);
                            if (isOrderTranist == 1)
                            {
                                CalculateOrderShortestRoute(pItem.Key);
                                UpdateOrderStatusInTransit(pItem.Key);
                                MessageBox.Show("Successfully updated orders!");
                                TrackInfo.addMessage("Porosia eshte ne tranzit ne : " + getPikePostareNameById(qytetiAktual), pItem.Key);
                            } else
                            {
                                UpdateStatusDorezuar(pItem.Key);
                                TrackInfo.addMessage("Porosia ka mberritur ne piken postare : " + getPikePostareNameById(qytetiAktual), pItem.Key);
                            }
                            if (sendMail)
                            {
                                Mail.sendMail("Posta@Sherbime.al", getClientEmail(pItem.Key), "Porosia u vona!", "Ju njoftojme se porosia juaj eshte vonuar!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string getClientEmail(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id_qytetar FROM Orders Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return getUserEmail(Convert.ToInt32(reader["id_qytetar"]));
                        }
                        return "";
                    }
                }
            }
        }

        private string getUserEmail(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT email FROM Users Where user_id = @user_id", connection))
                {
                    command.Parameters.AddWithValue("@user_id", clientId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["email"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        private int getPakoKohezgjatje(int pako_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT kohezgjatja FROM Pakot Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", pako_id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader["kohezgjatja"]);
                        }
                        return 0;
                    }
                }
            }
        }

        private DateTime getPakoCreatedAt(int pako_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT created_at FROM Pakot Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", pako_id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToDateTime(reader["created_at"]);
                        }
                        return new DateTime();
                    }
                }
            }
        }

        private void UpdateOrderStatusInTransit(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update Orders Set order_status = @order_status Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    command.Parameters.AddWithValue("@order_status", Convert.ToInt32(ConfigurationManager.AppSettings["NeTranzit"]));
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateStatusDorezuar(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update Orders Set order_status = @order_status Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    command.Parameters.AddWithValue("@order_status", Convert.ToInt32(ConfigurationManager.AppSettings["MberriturNePikePostare"]));
                    command.ExecuteNonQuery();
                }
            }
        }

        private int getQytetAktual(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT qyteti_aktual FROM Orders Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader["qyteti_aktual"]);
                        }
                        return 0;
                    }
                }
            }
        }

        private void UpdateQytetiAktual(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Update Orders Set qyteti_aktual = @qyteti_aktual Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    command.Parameters.AddWithValue("@qyteti_aktual", GetPikePostareToDrop(orderId));
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetPikePostareToDrop(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT pike_postare_to_drop FROM Orders Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader["pike_postare_to_drop"]);
                        }
                        return 0;
                    }
                }
            }
        }

        private int checkIfOrderIsTransit(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT pike_postare_to_drop, pike_postare_id FROM Orders Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int pikePostareToDrop = Convert.ToInt32(reader["pike_postare_to_drop"]);
                            int pikePostareDestinacion = Convert.ToInt32(reader["pike_postare_id"]);

                            if (pikePostareToDrop == pikePostareDestinacion)
                            {
                                return 0;
                            } else
                            {
                                return 1;
                            }
                        }
                        return 0;
                    }
                }
            }
        }

        private void CalculateOrderShortestRoute(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Orders Where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int pikePostareNisje = Convert.ToInt32(reader["qyteti_aktual"]);
                            int pikePostareDestinacion = Convert.ToInt32(reader["pike_postare_id"]);
                            int order_id = Convert.ToInt32(reader["id"]);
                            FindShortestRoute(pikePostareNisje, pikePostareDestinacion, order_id);
                        }
                    }
                }
            }
        }

        private void FindShortestRoute(int pikePostareNisje, int pikePostareDestinacion, int orderId)
        {
            int starterCityId = 0, destinationCityId = 0, durationLength = 0;
            var graph = new Dictionary<string, Dictionary<string, int>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SElECT * FROM Rruget WHERE is_priority = @is_priority", connection);
                connection.Open();
                command.Parameters.AddWithValue("@is_priority", 0);
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
            var shortestRoute = shortestRouteFinder.FindShortestRoute(pikePostareNisje.ToString(), pikePostareDestinacion.ToString());

            List<int> shortestPathInt = shortestRoute.Select(int.Parse).ToList();
            int cityToDrop = -1; // Initialize with a default value

            // Start from the end of the shortest path and iterate backward
            for (int i = shortestPathInt.Count - 1; i >= 0; i--)
            {
                int currentCity = shortestPathInt[i];

                // Check if the current city is directly connected to city 5
                if (currentCity != pikePostareNisje && graph.ContainsKey(pikePostareNisje.ToString()) && graph[pikePostareNisje.ToString()].ContainsKey(currentCity.ToString()))
                {
                    cityToDrop = currentCity;
                }
            }

            //add cityToDrop to porosi in database and then change the pako form to add only orders by citytodrop and then update the citytodrop when porosi arrives at the city to be dropeed
            UpdateCityToDrop(cityToDrop, orderId, pikePostareNisje);
        }

        private void UpdateCityToDrop(int pikePostareToDrop, int orderId, int actualCity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Update Orders Set pike_postare_to_drop = @pike_postare_to_drop, qyteti_aktual = @qyteti_aktual Where id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@pike_postare_to_drop", pikePostareToDrop);
                        command.Parameters.AddWithValue("@id", orderId);
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

        public void setPakoId(int pako_id)
        {
            pakoId = pako_id;
        }
    }
}
