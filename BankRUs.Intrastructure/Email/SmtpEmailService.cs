using BankRUs.Application.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BankRUs.Intrastructure.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public SmtpEmailService(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string name)
        {
            var body = $@"
                <html>
                <body>
                    <p>Hi {name}!</p>
                    <p>Your account is now created 🎉</p>
                    <p>Best regards,<br/>BankRUs Team</p>
                </body>
                </html>
            ";

            var message = new MailMessage(_settings.From, toEmail, "Welcome to the bank!", body)
            {
                IsBodyHtml = true
            };

            var smtpClient = new SmtpClient(_settings.Host, _settings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            await smtpClient.SendMailAsync(message);
        }
        public async Task SendAccountCreatedEmailAsync(string toEmail, string accountNumber)
        {
            var body = $@"
                <html>
                <body>
                    <p>Hello,</p>
                    <p>Your new bank account has been successfully created 🎉</p>
                    <p><strong>Account Number: {accountNumber}</strong></p>
                    <p>Thank you for choosing BankRUs!</p>
                    <p>Best regards,<br/>BankRUs Team</p>
                </body>
                </html>
            ";

            var message = new MailMessage(_settings.From, toEmail, "Your Bank Account Has Been Created", body)
            {
                IsBodyHtml = true
            };
            var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            await client.SendMailAsync(message);
        }
    }
}

