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
    public partial class SportelistRaporte : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Label porosiTeKrijuaraLabel, porosiTeKrijuaraMeShumeLabel, porosiaTeKrijuaraPrioritet, porosiTeKrijuaraPaPrioritet;
        public DateTimePicker fromDateInput, toDateInput;
        int sportelistId = 0, roleId = 0;
        bool isAdmin = true;

        private void shfaqButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromDateInput.Value.Date;
            DateTime toDate = toDateInput.Value.Date.AddDays(1).AddSeconds(-1);
            updatePorosiTeKrijuara(fromDate, toDate);
            updatePorosiTeKrijuaraPaPrioritet(fromDate, toDate);
            if (isAdmin)
            {
                updatePorosiTeKrijuaraMeShume(fromDate, toDate);
            }
            updatePorosiTeKrijuaraMePrioritet(fromDate, toDate);
        }

        public SportelistRaporte()
        {
            InitializeComponent();
            porosiTeKrijuaraLabel = porosiTeKrijuara;
            porosiTeKrijuaraMeShumeLabel = porosiTeKrijuaraMeShume;
            porosiaTeKrijuaraPrioritet = porosiMePrioritet;
            porosiTeKrijuaraPaPrioritet = porosiPaPrioritet;
            fromDateInput = fromDate;
            toDateInput = toDate;
        }

        public void setSportelistId(int id)
        {
            sportelistId = id;
        }

        public void setRoleId(int role_id)
        {
            roleId = role_id;
            if (roleId != Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]))
            {
                isAdmin = false;
            }
        }

        private void updatePorosiTeKrijuara(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND sportelist_id = @sportelist_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@sportelist_id", sportelistId);
                }
                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);

                connection.Open();
                int result = (int)command.ExecuteScalar();

                porosiTeKrijuaraLabel.Text = "Porosi te krijuara: " + result;
            }
        }

        private void updatePorosiTeKrijuaraPaPrioritet(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE is_priority = @is_priority AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND sportelist_id = @sportelist_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@sportelist_id", sportelistId);
                }
                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                command.Parameters.AddWithValue("@is_priority", 0);

                connection.Open();
                int result = (int)command.ExecuteScalar();

                porosiTeKrijuaraPaPrioritet.Text = "Porosi te krijuara pa prioritet: " + result;
            }
        }

        private void updatePorosiTeKrijuaraMeShume(DateTime from, DateTime to)
        {
            string query = "SELECT sportelist_id, COUNT(*) AS Total FROM Orders WHERE created_at >= @FromDate AND created_at <= @ToDate GROUP BY sportelist_id ORDER BY Total DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int id = 0, total = 0;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["sportelist_id"]);
                    total = Convert.ToInt32(reader["Total"]);
                    break;
                }
                porosiTeKrijuaraMeShumeLabel.Text = getUsernameById(id) + " ka krijuar me shume porosi : " + total;
            }
        }

        private string getUsernameById(int id)
        {
            string query = "SELECT username From Users WHERE user_id = @user_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@user_id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader["Username"].ToString();
                }
                return "";
            }
        }

        private void updatePorosiTeKrijuaraMePrioritet(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE is_priority = @is_priority AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND sportelist_id = @sportelist_id";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                command.Parameters.AddWithValue("@is_priority", 1);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@sportelist_id", sportelistId);
                }
                connection.Open();
                int result = (int)command.ExecuteScalar();
                porosiaTeKrijuaraPrioritet.Text = "Porosi te krijuara me prioritet: " + result;
            }
        }
    }
}
