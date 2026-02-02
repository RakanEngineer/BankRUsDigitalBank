using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace BankRUs.Domain.Entities
{
    public class BankAccount
    {
        // Det här är en entitet som inte finns i databasen
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }   // 🔗 // Foreign Key to ApplicationUser
        [MaxLength(25)]
        public string AccountNumber { get; protected set; }
        [MaxLength(25)]
        public string Name { get; protected set; }
        public bool IsLocked { get; protected set; }
        public decimal Balance { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public void Deposit(decimal amount, string reference) { }
        public void Withdraw(decimal amount, string reference) { }

        private BankAccount() { } // EF

        public BankAccount(Guid userId, string accountNumber, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            AccountNumber = accountNumber;
            Name = name;
            Balance = 0;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
