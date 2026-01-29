using BankRUs.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Intrastructure.Email
{
    public class EmailService : IEmailService
    {
        public Task SendAccountCreatedEmailAsync(string toEmail, string accountNumber)
        {
            // Skicka riktiga email...
            throw new NotImplementedException();
        }
        public Task SendWelcomeEmailAsync(string toEmail, string name)
        {
            // Skicka riktiga email...
            throw new NotImplementedException();
        }
    }
}
