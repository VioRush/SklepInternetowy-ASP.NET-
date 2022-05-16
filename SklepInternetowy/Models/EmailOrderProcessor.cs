using SklepInternetowy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace SklepInternetowy.Models
{   public class EmailSettings
    {
        public string MailToAddress = "violetta.rushnitskaya@gmail.com";
        public string MailFromAddress = "sklepInternetowy@example.com";
        public bool UseSsl = true;
        public string Username = "MyProjektUsername";
        public string Password = "MyProjektUsername";
        public int ServerPort = 587;
        public string ServerName = "smtp.example.com";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor()
        {
            emailSettings = new EmailSettings();
        }
        public void ProcessOrder(Cart cart, DeliveryAddress deliveryAddress)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder body = new StringBuilder().AppendLine("Twoje zamówienie zostało złożone").AppendLine("Zamówione produkty: ");
                foreach (var line in cart.Lines)
                {
                    body.AppendFormat(line.product.Name + " " + line.Quantity + "*" + line.product.Price + "     " + line.Quantity * line.product.Price + "zł");

                }
                body.AppendFormat("Lączna suma: " + cart.ComputeTotalValue())
                    .AppendLine("Dane do dostawy:")
                    .AppendLine(deliveryAddress.UserName)
                    .AppendLine(deliveryAddress.UserSurname)
                    .AppendLine(deliveryAddress.Country)
                    .AppendLine(deliveryAddress.City)
                    .AppendLine(deliveryAddress.Street)
                    .AppendLine(deliveryAddress.Address)
                    .AppendLine(deliveryAddress.PostalCode.ToString());

                MailMessage mailMessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress,"jhvj", body.ToString());
                smtpClient.Send(mailMessage);
            }
        }
    }
}