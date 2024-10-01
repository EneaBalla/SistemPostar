using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemPostar
{
    internal class Mail
    {
        public static void sendMail(string from, string to, string title, string message)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("e235711038fedf", "8145b65b370e11"),
                EnableSsl = true
            };
            client.Send(from, to, title, message);
        }
    }
}
