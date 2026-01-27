using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankRUs.Domain.Entities
{
    public class BankAccount
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }   // 🔗 // Foreign Key to ApplicationUser
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private BankAccount() { } // EF

        public BankAccount(Guid userId, string accountNumber)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            AccountNumber = accountNumber;
            Balance = 0;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
