using BankRUs.Application.Identity;
using BankRUs.Application.Interfaces;
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
        //private readonly IEmailService _emailService;
        //private readonly IIdentityService _identityService;
        public OpenBankAccountHandler(IBankAccountRepository repo)
        {
            _repo = repo;
        }
        //public OpenBankAccountHandler(
        //IBankAccountRepository repo,
        //IEmailService emailService,
        //IIdentityService identityService)
        //{
        //    _repo = repo;
        //    _emailService = emailService;
        //    _identityService = identityService;
        //}
        public async Task Handle(OpenBankAccountCommand command)
        {
            var accountNumber = AccountNumberGenerator.Generate(); //

            var account = new BankAccount(
                command.UserId,
                accountNumber,
                "Standardkonto"
            );

            await _repo.AddAsync(account);

            //var user = await _identityService.GetUserByIdAsync(command.UserId);

            //await _emailService.SendAccountCreatedEmailAsync(
            //    user.Email,
            //    accountNumber
            //);
        }
        
    }
}
