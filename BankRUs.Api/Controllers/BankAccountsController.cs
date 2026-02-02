using BankRUs.Api.Dtos.BankAccounts;
using BankRUs.Application.UseCases.OpenBankAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BankRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly OpenBankAccountHandler _handler;
        public BankAccountsController(OpenBankAccountHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("/api/bank-accounts")]
        //public async Task<IActionResult> OpenBankAccount(OpenBankAccountCommand command)
        public async Task<IActionResult> OpenBankAccount(CreateBankAccountRequestDto request)
        {
            //await _handler.HandleAsync(command);
            //return Ok();
            var result = await _handler.HandleAsync(
            new OpenBankAccountCommand(UserId: request.UserId));

            var response = new BankAccountDto(
                Id: result.Id,
                AccountNumber: result.AccountNumber,
                Name: result.Name,
                IsLocked: false,
                Balance: result.Balance,
                UserId: result.UserId
            );

            return Created(string.Empty, response);
        }
    }
}
