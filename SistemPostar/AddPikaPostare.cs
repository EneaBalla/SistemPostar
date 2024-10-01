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

namespace SistemPostar
{
    public partial class AddPikaPostare : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public TextBox name, numerPostar, address, city;
        public NumericUpDown cmimiPeshe, tarifaPrioritet;
        int id = 0;
        int currentPikePostareStatus = 0;

        public AddPikaPostare()
        {
            InitializeComponent();
            name = namePikePostareForm;
            numerPostar = numerPostarForm;
            address = addressPikePostareForm;
            city = cityPikePostareForm;
            cmimiPeshe = cmimiPesheField;
            tarifaPrioritet = cmimiPrioritetInput;
        }

        private void saveUserButton_Click(object sender, EventArgs e)
        {
            bool isUpdate = true;
            if (!checkInputs())
            {
                MessageBox.Show("Please fill in all the fields!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "";
            if (id == 0)
            {
                query = "INSERT INTO PikatPostare(name, address, city, numer_postar, status, cmimPesha, tarifePrioritet) VALUES(@name, @address, @city, @numer_postar, @status, @cmimPesha, @tarifePrioritet)";
                updatePikatPostareTable(query, false);
            }
            else
            {
                query = "UPDATE PikatPostare SET name = @name, address = @address, city = @city, numer_postar = @numer_postar, updated_at = @updated_at, cmimPesha = @cmimPesha, tarifePrioritet = @tarifePrioritet WHERE id = @id";
                updatePikatPostareTable(query, isUpdate);
            }
        }

        private bool checkInputs()
        {
            if (string.IsNullOrEmpty(name.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(numerPostar.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(address.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrEmpty(city.Text.Trim()))
            {
                return false;
            }
            if (cmimiPeshe.Value == 0 ) 
            {
                return false;
            }
            if (tarifaPrioritet.Value == 0)
            {
                return false;
            }
            return true;
        }

        private void updatePikatPostareTable(string query, bool update)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name.Text);
                        command.Parameters.AddWithValue("@address", address.Text);
                        command.Parameters.AddWithValue("@city", city.Text);
                        command.Parameters.AddWithValue("@numer_postar", numerPostar.Text);
                        command.Parameters.AddWithValue("@status", currentPikePostareStatus);
                        command.Parameters.AddWithValue("@cmimPesha", cmimiPeshe.Value);
                        command.Parameters.AddWithValue("@tarifePrioritet", tarifaPrioritet.Value);
                        if (update)
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@updated_at", DateTime.Now);
                        }
                        if (command.ExecuteNonQuery() > 0)
                        {
                            if (update)
                            {
                                MessageBox.Show("Successfully updated Pike Postare!");
                            }
                            else
                            {
                                MessageBox.Show("Successfully added Pike Postare!");
                                clearInputs();
                            }
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
            name.Text = string.Empty;
            numerPostar.Text = string.Empty;
            city.Text = string.Empty;
            address.Text = string.Empty;
            cmimiPeshe.Value = 0;
            tarifaPrioritet.Value = 0;
        }

        public void setPikePostareId(int pikePostareId)
        {
            id = pikePostareId;
        }

        public void setCurrentPikePostareStatus(int status)
        {
            currentPikePostareStatus = status;
        }
    }
}
