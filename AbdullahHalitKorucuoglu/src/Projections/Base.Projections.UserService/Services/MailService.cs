﻿using System.Net;
using System.Net.Mail;

namespace Base.Projections.UserService
{
    public class MailService : IMailService
    {
        private readonly IMailSettings _mailSettings;

        public MailService(IMailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task Send(string toMailAdress, string message, string subject)
        {
            using var smtp = new SmtpClient
            {
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailSettings.MailAdress, _mailSettings.MailPassword)
            };
            using var data = new MailMessage(_mailSettings.MailAdress, toMailAdress) { Subject = subject, Body = message };
            data.IsBodyHtml = true;

            await smtp.SendMailAsync(data);
        }
    }
}