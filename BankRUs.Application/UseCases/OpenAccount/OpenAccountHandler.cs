using BankRUs.Application.Identity;
using BankRUs.Application.Interfaces;
using BankRUs.Application.Repository;
using BankRUs.Domain.Entities;

namespace BankRUs.Application.UseCases.OpenAccount;

public class OpenAccountHandler
{
    private readonly IIdentityService _identityService;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IEmailService _emailService;

    public OpenAccountHandler(
        IIdentityService identityService,
        IBankAccountRepository bankAccountRepository,
        IEmailService emailService
       )
    {
        _identityService = identityService;
        _bankAccountRepository = bankAccountRepository;
        _emailService = emailService;
    }

    public async Task<OpenAccountResult> HandleAsync(OpenAccountCommand command)
    {
        // TODO: Skapa användarkonto (ASP.NET Core Identity)
        // Delegera till infrastructure
        var createUserResult = await _identityService.CreateUserAsync(
            new CreateUserRequest(
            FirstName: command.FirstName,
            LastName: command.LastName,
            SocialSecurityNumber: command.SocialSecurityNumber,
            Email: command.Email
         ));

        // TODO: SocialSecurityNumber + Email ska vara UNIQUE

        // TODO: Skapa bankkonto
        // Delegera till infrastructure
        var userId = createUserResult.UserId;
        var accountNumber = GenerateAccountNumber();

        var bankAccount = new BankAccount(
            userId: userId,
            accountNumber: accountNumber
        );

        await _bankAccountRepository.AddAsync(bankAccount);
        // TODO: Skicka välkomstmail till kund
        // Delegera till infrastructure
        // _emailSender.Send("Ditt bankkonto är nu redo!");
        await _emailService.SendWelcomeEmailAsync(
            command.Email,
            command.FirstName
        );

        return new OpenAccountResult(UserId: createUserResult.UserId);
    }
    private static string GenerateAccountNumber()
    {
        return $"SE-{Random.Shared.Next(10000000, 99999999)}";
    }
}