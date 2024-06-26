﻿using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MeetingApp.Service.Mail
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));

            foreach(var mail in mailRequest.ToEmail)
            {
                email.To.Add(MailboxAddress.Parse(mail));
            }

            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
           
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
