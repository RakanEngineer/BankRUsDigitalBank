using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string name);
    }
}
