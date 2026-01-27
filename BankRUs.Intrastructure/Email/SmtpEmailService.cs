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
            var message = new MailMessage(
                _settings.From,
                toEmail,
                "Welcome to the bank!",
                $"Hi {name}!\n\nYour account is now created 🎉"
            );

            var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            await client.SendMailAsync(message);
        }
    }
}

