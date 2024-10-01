using System.Configuration;
using System.Data.SqlClient;

namespace SistemPostar
{
    internal class TrackInfo
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public static void addMessage(string message, int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Insert Into Transportet(order_id, message) Values (@order_id, @message)", connection))
                {
                    command.Parameters.AddWithValue("@message", message);
                    command.Parameters.AddWithValue("@order_id", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
