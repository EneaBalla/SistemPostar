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
    public partial class TransportuesRaporte : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Label pakoTeKrijuaraLabel, pakoTeKrijuaraPriority, pakoTeDorezuar, pakoNePritjeInput;
        public DateTimePicker fromDateInput, toDateInput;
        int transportuesId = 0, roleId = 0;
        bool isAdmin = true;

        public TransportuesRaporte()
        {
            InitializeComponent();
            fromDateInput = fromDate;
            toDateInput = toDate;
            pakoTeKrijuaraLabel = pakoTeKrijuara;
            pakoTeKrijuaraPriority = pakoMePrioritet;
            pakoTeDorezuar = pakoTeDorezuara;
            pakoNePritjeInput = pakoNePritje;
        }

        public void setTransportuesId(int id)
        {
            transportuesId = id;
        }
        
        public void setRoleId(int id)
        {
            roleId = id;
            if (roleId != Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]))
            {
                isAdmin = false;
            }
        }

        private void shfaqButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromDateInput.Value.Date;
            DateTime toDate = toDateInput.Value.Date.AddDays(1).AddSeconds(-1);
            updatePorosiTeKrijuara(fromDate, toDate);
            if (isAdmin)
            {
                updateMostCreatedPako(fromDate, toDate);
            }
            updatePakoTeDorezuara(fromDate, toDate);
            updatePakoNePritje(fromDate, toDate);
        }

        private void updatePorosiTeKrijuara(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Pakot WHERE created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND created_by = @created_by";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@created_by", transportuesId);
                }

                connection.Open();
                int result = (int)command.ExecuteScalar();

                pakoTeKrijuara.Text = "Pako te krijuara: " + result;
            }
        }

        private void updateMostCreatedPako(DateTime from, DateTime to)
        {
            string query = "SELECT created_by, COUNT(*) AS Total FROM Pakot WHERE created_at >= @FromDate AND created_at <= @ToDate GROUP BY created_by ORDER BY Total DESC";

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
                    id = Convert.ToInt32(reader["created_by"]);
                    total = Convert.ToInt32(reader["Total"]);
                    break;
                }
                pakoTeKrijuaraPriority.Text = getUsernameById(id) + " ka krijuar me shume pako : " + total;
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

        private void updatePakoTeDorezuara(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Pakot WHERE status_dergesa = @status_dergesa AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND created_by = @created_by";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                command.Parameters.AddWithValue("@status_dergesa", ConfigurationManager.AppSettings["PakoDorezuar"]);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@created_by", transportuesId);
                }
                connection.Open();
                int result = (int)command.ExecuteScalar();

                pakoTeDorezuar.Text = "Pako te cilat jane dorezuar: " + result;
            }
        }

        private void updatePakoNePritje(DateTime from, DateTime to)
        {
            string query = "SELECT COUNT(*) FROM Pakot WHERE status_dergesa = @status_dergesa AND created_at >= @FromDate AND created_at <= @ToDate";
            if (!isAdmin)
            {
                query += " AND created_by = @created_by";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FromDate", from);
                command.Parameters.AddWithValue("@ToDate", to);
                command.Parameters.AddWithValue("@status_dergesa", ConfigurationManager.AppSettings["PakoPritje"]);
                if (!isAdmin)
                {
                    command.Parameters.AddWithValue("@created_by", transportuesId);
                }
                connection.Open();
                int result = (int)command.ExecuteScalar();

                pakoNePritjeInput.Text = "Pako te cilat ndodhen ne pritje: " + result;
            }
        }
    }
}
