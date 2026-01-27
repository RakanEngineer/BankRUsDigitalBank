using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Intrastructure.Email
{
    public class SmtpSettings
    {
        public string Host { get; set; } = "localhost"; // smtp4dev
        public int Port { get; set; } = 25;
        public string From { get; set; } = "no-reply@bankrus.com";
    }
}
