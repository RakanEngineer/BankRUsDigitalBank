using BankRUs.Application.Repository;
using BankRUs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Application.UseCases.OpenBankAccount
{
    public class OpenBankAccountHandler
    {
        private readonly IBankAccountRepository _repo;
        public OpenBankAccountHandler(IBankAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(OpenBankAccountCommand command)
        {
            var accountNumber = AccountNumberGenerator.Generate(); //

            var account = new BankAccount(
                command.UserId,
                accountNumber,
                "Standardkonto"
            );

            await _repo.AddAsync(account);
        }
        
    }
}
