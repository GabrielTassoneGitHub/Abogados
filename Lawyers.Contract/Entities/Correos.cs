using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Lawyers.Contract.Entities
{
    public class Correos
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        public void EnviarEmail(string from, string password, string to, string mensaje, string asunto)
        {
            try
            {
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Body = mensaje;
                message.Subject = asunto;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.EnableSsl = true;
                smtp.Send(message);

            }
            catch (Exception e)
            {
                
            }
            
        }
    }
}
