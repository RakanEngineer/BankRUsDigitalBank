using BankRUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Application.Repository
{
    public interface IBankAccountRepository
    {
        Task Add(BankAccount bankAccount);
        //Task<BankAccount> Add(BankAccount bankAccount);

        Task<BankAccount?> GetByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<BankAccount>> GetByUserIdAsync(Guid userId);
    }
}
