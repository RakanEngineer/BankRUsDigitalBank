using BankRUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Application.Repository
{
    public interface IBankAccountRepository
    {
        Task CreateBankAccount(BankAccount account);
        Task<BankAccount?> GetByAccountNumberAsync(string accountNumber);
        Task<IEnumerable<BankAccount>> GetByUserIdAsync(Guid userId);
    }
}
