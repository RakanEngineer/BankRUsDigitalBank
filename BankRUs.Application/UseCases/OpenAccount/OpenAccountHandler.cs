using BankRUs.Application.Identity;
using BankRUs.Application.Interfaces;
using BankRUs.Application.Repository;
using BankRUs.Application.UseCases.OpenBankAccount;
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
        // TODO: SocialSecurityNumber + Email ska vara UNIQUE
        // Check if user already exists
        if (await _identityService.UserExistsAsync(
            command.Email,
            command.SocialSecurityNumber))
        {
            throw new Exception("This user already exists.");
        }
        
        // TODO: Skapa användarkonto (ASP.NET Core Identity)
        // Delegera till infrastructure
        var createUserResult = await _identityService.CreateUserAsync(
            new CreateUserRequest(
            FirstName: command.FirstName,
            LastName: command.LastName,
            SocialSecurityNumber: command.SocialSecurityNumber,
            Email: command.Email
         ));
        
        // TODO: Skapa bankkonto
        // Delegera till infrastructure
        var userId = createUserResult.UserId;
        var accountNumber = AccountNumberGenerator.Generate();

        var bankAccount = new BankAccount(
            userId: userId,
            accountNumber: accountNumber,
            name: "Standardkonto"
        );

        await _bankAccountRepository.AddAsync(bankAccount);
        // TODO: Skicka välkomstmail till kund
        // Delegera till infrastructure
        // _emailSender.Send("Ditt bankkonto är nu redo!");
        await _emailService.SendWelcomeEmailAsync(
            command.Email,
            command.FirstName
        );

        await _emailService.SendAccountCreatedEmailAsync(command.Email, accountNumber);

        return new OpenAccountResult(UserId: createUserResult.UserId);
    }   
}