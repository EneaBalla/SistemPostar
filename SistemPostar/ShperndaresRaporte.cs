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
    public partial class ShperndaresRaporte : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Label PorosiTeKthyera, PorosiTeDorezuara, PorosiKlientiNukEshtePergjigjur;
        public DateTimePicker fromDateInput, toDateInput;
        int shperndares = 0;
        int shperndaresRole = 0;
        bool isAdmin = true;

        public ShperndaresRaporte()
        {
            InitializeComponent();
            PorosiTeKthyera = porosiTeKthyera;
            PorosiTeDorezuara = porosiTeDorezuaraLabel;
            PorosiKlientiNukEshtePergjigjur = klientiNukKaKthyerPergjigje;
            fromDateInput = fromDate;
            toDateInput = toDate;
        }

        public void setShperndaresId(int id)
        {
            shperndares = id;
        }

        public void setShperndaresRole(int roleId)
        {
            shperndaresRole = roleId;
            if (shperndaresRole != Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]))
            {
                isAdmin = false;
            }
        }

        private void shfaqButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromDateInput.Value.Date;
            DateTime toDate = toDateInput.Value.Date.AddDays(1).AddSeconds(-1);
            updatePorosiTeDorezuara(fromDate, toDate);
            updatePorosiTeKthyera(fromDate, toDate);
            updatePorosiKlientiNukKthenPergjigje(fromDate, toDate);
        }

        private void updatePorosiTeDorezuara(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE order_status = @order_status AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND zone_mbulimi_id = @zone_mbulimi_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@order_status", ConfigurationManager.AppSettings["OrderDorezuar"]);
                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@zone_mbulimi_id", getZoneMbulimiIdByShperndares());
                }
                connection.Open();
                int result = (int)command.ExecuteScalar();

                PorosiTeDorezuara.Text = "Porosi te dorezuara tek klienti: " + result;
            }
        }

        private int getZoneMbulimiIdByShperndares()
        {
            string query = "SELECT zone_mbulimi_id FROM Users WHERE user_id = @user_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@user_id", shperndares);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return Convert.ToInt32(reader["zone_mbulimi_id"]);
                }
                return 0;
            }
        }

        private void updatePorosiTeKthyera(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE order_status = @order_status AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND zone_mbulimi_id = @zone_mbulimi_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@order_status", ConfigurationManager.AppSettings["OrderRefuzuar"]);
                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@zone_mbulimi_id", getZoneMbulimiIdByShperndares());
                }

                connection.Open();
                int result = (int)command.ExecuteScalar();

                PorosiTeKthyera.Text = "Porosi te refuzuara nga klienti: " + result;
            }
        }

        private void updatePorosiKlientiNukKthenPergjigje(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE order_status = @order_status AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND zone_mbulimi_id = @zone_mbulimi_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@order_status", ConfigurationManager.AppSettings["KlientiNukEshtePergjigjur"]);
                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@zone_mbulimi_id", getZoneMbulimiIdByShperndares());
                }
                connection.Open();
                int result = (int)command.ExecuteScalar();

                PorosiKlientiNukEshtePergjigjur.Text = "Porosi ku klienti nuk eshte pergjigjur: " + result;
            }
        }
    }
}
