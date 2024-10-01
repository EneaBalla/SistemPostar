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
using ZXing.QrCode.Internal;
using ZXing;

namespace SistemPostar
{
    public partial class AddPako : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public ComboBox pikePostareInput;
        public ListBox porosiInput, pakoOutput;
        static int transportuesId = 0;
        int isPriority = 0;

        public AddPako()
        {
            InitializeComponent();
            pikePostareInput = pikePostareComboBox;
            porosiInput = porosiListBox;
            pakoOutput = pakoListBox;
            porosiInput.SelectionMode = SelectionMode.MultiExtended;
            pakoOutput.SelectionMode = SelectionMode.MultiExtended;
            PopulatePikePostareComboBox();
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

        public void setTransportuesId(int id)
        {
            transportuesId = id;
        }

        private void pikePostareComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            porosiInput.Items.Clear();
            pakoOutput.Items.Clear();
            PopulatePorosiListBox(((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key);
        }

        private void PopulatePorosiListBox(int key)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, order_number, zone_mbulimi_id, order_status FROM Orders WHERE pike_postare_to_drop = @pike_postare_to_drop AND order_status <> @order_status AND is_priority = @is_priority AND qyteti_aktual = @qyteti_aktual ORDER BY updated_at DESC", connection))
                {
                    command.Parameters.AddWithValue("@pike_postare_to_drop", key);
                    command.Parameters.AddWithValue("@order_status", Convert.ToInt32(ConfigurationManager.AppSettings["MberriturNePikePostare"]));
                    command.Parameters.AddWithValue("@is_priority", isPriority);
                    command.Parameters.AddWithValue("@qyteti_aktual", getPikePostareIdByTransportues(transportuesId));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string label = reader["order_number"].ToString() + " || " + getZoneMbulimiNameById(Convert.ToInt32(reader["zone_mbulimi_id"])) + " || " + getOrderStatusLabelById(Convert.ToInt32(reader["order_status"]));

                            PorosiItem pItem = new PorosiItem { Key = id, Value = label};
                            porosiInput.Items.Add(pItem);
                        }
                    }
                }
            }
        }

        private string getZoneMbulimiNameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT name FROM ZonaMbulimi WHERE id = @id", connection))
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

        private string getOrderStatusLabelById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT status_name FROM OrderStatuses WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["status_name"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        private void addToPakoButton_Click(object sender, EventArgs e)
        {
            foreach(var selectedItem in porosiInput.SelectedItems)
            {
                if (!pakoOutput.Items.Contains(selectedItem)) 
                {
                    pakoOutput.Items.Add(selectedItem);
                }
            }
        }

        private void removePorosiButton_Click(object sender, EventArgs e)
        {
            List<PorosiItem> pItemList = new List<PorosiItem>();
            foreach (PorosiItem selectedItem in pakoOutput.SelectedItems)
            {
                pItemList.Add(selectedItem);
            }

            foreach (PorosiItem pItem in pItemList)
            {
                pakoOutput.Items.Remove(pItem);
            }
            pItemList.Clear();
        }

        private void AddPako_Load(object sender, EventArgs e)
        {
        }

        private void createPakoButton_Click(object sender, EventArgs e)
        {
            try
            {
                int pikaPostareNisje = getPikePostareIdByTransportues(transportuesId);
                int destinacionId = ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key;
                int pakoNumber = GetMaxPakoNumber() + 1;
                string barcode = "";
                string kohezgjatja = GetTransportDuration(pikaPostareNisje, destinacionId);
                foreach (PorosiItem items in pakoOutput.Items)
                {
                    barcode += items.getValue().Split('|')[0].ToString().Trim();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"
                        DECLARE @InsertedIDs TABLE (ID INT); -- Declare table variable
                        INSERT INTO Pakot(barcode, pike_postare_id, created_by, status_dergesa, pika_postare_nisje, pako_number, kohezgjatja) 
                        OUTPUT INSERTED.ID INTO @InsertedIDs(ID) -- Use table variable in OUTPUT INTO clause
                        VALUES (@barcode, @pike_postare_id, @created_by, @status_dergesa, @pika_postare_nisje, @pako_number, @kohezgjatja);
        
                        SELECT ID FROM @InsertedIDs; -- Retrieve ID from table variable
                    ", connection))
                    {
                        command.Parameters.AddWithValue("@barcode", barcode);
                        command.Parameters.AddWithValue("@pike_postare_id", destinacionId);
                        command.Parameters.AddWithValue("@created_by", transportuesId);
                        command.Parameters.AddWithValue("@status_dergesa", Convert.ToInt32(ConfigurationManager.AppSettings["CreatedPakoStatusId"]));
                        command.Parameters.AddWithValue("@pika_postare_nisje", pikaPostareNisje);
                        command.Parameters.AddWithValue("@pako_number", pakoNumber.ToString());
                        command.Parameters.AddWithValue("@kohezgjatja", kohezgjatja);

                        int newPakoId = (int)command.ExecuteScalar();

                        if (newPakoId > 0)
                        {
                            UpdatePorosiTable(newPakoId);
                            UpdatePakoDetails(pakoNumber, transportuesId, "Krijuar", pikaPostareNisje, ((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Value, kohezgjatja, barcode);
                            MessageBox.Show("Successfully added pako!");
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

        private string GetTransportDuration(int pikeNisjeId, int destinacionId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT kohezgjatje FROM Rruget WHERE pike_postare_nisje = @pike_postare_nisje AND pike_postare_destinacion = @pike_postare_destinacion AND is_priority = @is_priority", connection))
                {
                    command.Parameters.AddWithValue("@pike_postare_nisje", pikeNisjeId);
                    command.Parameters.AddWithValue("@pike_postare_destinacion", destinacionId);
                    command.Parameters.AddWithValue("@is_priority", isPriority);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["kohezgjatje"].ToString();
                        }
                        return "";
                    }
                }
            }
        }

        private void UpdatePakoDetails(int pakoNumber, int transportues_id, string status, int pikePostareNisje, string pikePostareDestinacion, string kohezgjatje, string barcode)
        {
            pakoNumberValue.Text = pakoNumber.ToString();
            transportuesValue.Text = getTransportuesUsernameById(transportues_id);
            statusValue.Text = status;
            pikePostareNisjeValue.Text = getPikePostareNameById(pikePostareNisje);
            pikePostareMberritjeValue.Text = pikePostareDestinacion;
            koheZgjatjaValue.Text = kohezgjatje + " Dite";
            updateQRCode(barcode);
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

        private int GetMaxPakoNumber()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ISNULL(MAX(TRY_CAST(pako_number AS INT)), 0) FROM Pakot";
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void UpdatePorosiTable(int pakoId)
        {
            foreach(PorosiItem pItem in pakoOutput.Items)
            {
                UpdateOrderRecord(pakoId, pItem.getKey());
            }
        }

        private void UpdateOrderRecord(int pakoId, int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Orders SET pako_id = @pako_id WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@pako_id", pakoId);
                    command.Parameters.AddWithValue("@id", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private int getPikePostareIdByTransportues(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT pike_postare_id FROM Users WHERE user_id = @user_id", connection))
                {
                    command.Parameters.AddWithValue("@user_id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["pike_postare_id"] != null)
                            {
                                return Convert.ToInt32(reader["pike_postare_id"]);
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        return 0;
                    }
                }
            }
        }

        private void priorityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            porosiListBox.Items.Clear();
            pakoListBox.Items.Clear();
            if (priorityCheckbox.Checked == true) 
            {
                isPriority = 1;
            } else
            {
                isPriority = 0;
            }
            PopulatePorosiListBox(((KeyValuePair<int, string>)pikePostareInput.SelectedItem).Key);
        }

        private void PopulatePikePostareComboBox()
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
                            int roleId = Convert.ToInt32(reader["id"]);
                            string roleName = reader["name"].ToString();

                            pikePostareInput.Items.Add(new KeyValuePair<int, string>(roleId, roleName));
                        }
                    }
                }
            }

            pikePostareInput.DisplayMember = "Value";
            pikePostareInput.ValueMember = "Key";
        }
    }
}
