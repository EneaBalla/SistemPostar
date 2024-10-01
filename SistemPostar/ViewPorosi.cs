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
using ZXing.QrCode.Internal;
using ZXing;
using System.Collections;

namespace SistemPostar
{
    public partial class ViewPorosi : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        int porosiId;
        public ComboBox statusInput;
        public ViewPorosi()
        {
            InitializeComponent();
            statusInput = statusComboBox;
        }

        public void setPorosiId(int porosi_id)
        {
            porosiId = porosi_id;
        }

        public void initializeStatusCombobox()
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
                            int id = Convert.ToInt32(reader["id"]);
                            string statusName = reader["status_name"].ToString();

                            statusInput.Items.Add(new KeyValuePair<int, string>(id, statusName));
                        }
                    }
                }
            }

            statusInput.DisplayMember = "Value";
            statusInput.ValueMember = "Key";
        }

        public void clearStatusComboBox()
        {
            statusInput.Items.Clear();
        }

        public void updateReceipt(int orderNumber, int sportelistId, int pikePostareDestinacionId, int zoneMbulimiId, int clientId, string barcode)
        {
            orderNumberValue.Text = orderNumber.ToString();
            sportelistValue.Text = getSportelistNumberById(sportelistId);
            pikePostareValue.Text = getPikePostareNameById(pikePostareDestinacionId);
            zoneMbulimiValue.Text = getZoneMbulimiNameById(zoneMbulimiId);
            klientiValue.Text = getClientUsernameById(clientId);
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

        public string getPikePostareNameById(int id)
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

        public string getZoneMbulimiNameById(int id)
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

        public string getClientUsernameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE user_id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
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

        public string getSportelistNumberById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE user_id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (((KeyValuePair<int, string>)statusInput.SelectedItem).Key == Convert.ToInt32(ConfigurationManager.AppSettings["OrderReadyForShperndares"]))
            {
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE Orders SET order_status = @order_status, updated_at = @updated_at WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@order_status", ((KeyValuePair<int, string>)statusInput.SelectedItem).Key);
                        command.Parameters.AddWithValue("@id", porosiId);
                        command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                        if (command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully updated order!");
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
