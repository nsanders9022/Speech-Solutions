//using System;
//using System.Net;
//using System.
//using System.Net.Mail;
//using System.dll;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Speech.Models
//{
//    public class SendContactEmail
//    {
//        public string sendit(string ReciverMail)
//        {
//            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
//            MailMessage msg = new MailMessage();

//            msg.From = new MailAddress("YourMail@gmail.com");
//            msg.To.Add(ReciverMail);
//            msg.Subject = "Hello world! " + DateTime.Now.ToString();
//            msg.Body = "hi to you ... :)";
//            SmtpClient client = new SmtpClient();
//            client.UseDefaultCredentials = true;
//            client.Host = "smtp.gmail.com";
//            client.Port = 587;
//            client.EnableSsl = true;
//            client.DeliveryMethod = SmtpDeliveryMethod.Network;
//            client.Credentials = new NetworkCredential("YourMail@gmail.com", "YourPassword");
//            client.Timeout = 20000;
//            try
//            {
//               client.Send(msg);
//                return "Mail has been successfully sent!";
//            }
//            catch (Exception ex)
//            {
//                return "Fail Has error" + ex.Message;
//            }
//            finally
//            {
//               msg.Dispose();
//            }
//      }

//    }
//}
