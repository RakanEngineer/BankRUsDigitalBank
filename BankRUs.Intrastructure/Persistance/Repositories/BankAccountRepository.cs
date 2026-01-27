using BankRUs.Application.Repository;
using BankRUs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Intrastructure.Persistance.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BankAccount account)
        {
            _context.BankAccounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<BankAccount?> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.BankAccounts
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task<IEnumerable<BankAccount>> GetByUserIdAsync(Guid userId)
        {
            return await _context.BankAccounts
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }
    }
}