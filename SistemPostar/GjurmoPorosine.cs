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
    public partial class GjurmoPorosine : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        static Form1 form1;
        int orderNumber = 0;

        public GjurmoPorosine()
        {
            InitializeComponent();
        }

        public void setForm1(Form1 form_1)
        {
            form1 = form_1;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }

        private void gjurmoButton_Click(object sender, EventArgs e)
        {
            orderNumber = Convert.ToInt32(gjurmoTextBox.Text);
            LoadOrderMessages(orderNumber);
        }

        private void LoadOrderMessages(int order_number)
        {
            int orderId = getOrderIdByOrderNumber(order_number);
            DisplayOrderUpdates(orderId);
        }

        private void DisplayOrderUpdates(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Transportet Where order_id = @order_id ORDER BY created_at DESC", connection))
                {
                    command.Parameters.AddWithValue("@order_id", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string label = reader["message"].ToString() + "   ||   " + reader["created_at"];
                            trackingInfo.Items.Add(label);
                        }
                    }
                }
            }
        }

        private int getOrderIdByOrderNumber(int order_number)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id FROM Orders Where order_number = @order_number", connection))
                {
                    command.Parameters.AddWithValue("@order_number", order_number);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader["id"]);
                        }
                        return 0;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
