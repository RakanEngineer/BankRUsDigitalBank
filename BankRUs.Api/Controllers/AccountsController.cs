using BankRUs.Api.Dtos.Accounts;
using BankRUs.Application.UseCases.OpenAccount;
using BankRUs.Application.UseCases.OpenBankAccount;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata;

namespace BankRUs.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly OpenAccountHandler _openAccountHandler;
    private readonly OpenBankAccountHandler _handler;

    public AccountsController(OpenAccountHandler openAccountHandler, OpenBankAccountHandler handler)
    {
        _openAccountHandler = openAccountHandler;
        _handler = handler;
    }

    // POST /api/accounts (Endpoint /  API endpoint)
    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountRequestDto request)
    {
        // Tjocka vs Tunna controllers

        var openAccountResult = await _openAccountHandler.HandleAsync(
            new OpenAccountCommand(
                FirstName: request.FirstName,
                LastName: request.LastName,
                SocialSecurityNumber: request.SocialSecurityNumber,
                Email: request.Email));

        var response = new CreateAccountResponseDto(openAccountResult.UserId);

        // Returnera 201 Created
        return Created(string.Empty, response);
    }
    //[HttpPost("/api/bank-accounts")]
    //public async Task<IActionResult> OpenBankAccount(OpenBankAccountCommand command)
    //{
    //    await _handler.HandleAsync(command);
    //    return Ok();
    //}

    private static bool IsValidLuhn(string digits)
    {
        var sum = 0;

        for (int i = 0; i < 9; i++)
        {
            var num = digits[i] - '0';
            num *= (i % 2 == 0) ? 2 : 1;
            if (num > 9) num -= 9;
            sum += num;
        }

        var controlDigit = (10 - (sum % 10)) % 10;

        return controlDigit == digits[9] - '0';
    }

}
