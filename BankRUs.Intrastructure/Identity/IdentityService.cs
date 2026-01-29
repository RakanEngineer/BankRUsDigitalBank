
using BankRUs.Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankRUs.Intrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    //public async Task<UserDto> GetUserByIdAsync(Guid userId)
    //{
    //    var user = await _userManager.Users
    //    .FirstAsync(u => u.Id == userId.ToString());

    //    return new UserDto(
    //        UserId: userId,
    //        Email: user.Email!,
    //        FullName: $"{user.FirstName} {user.LastName}"
    //    );
    //}
    public async Task<CreateUserResult> CreateUserAsync(CreateUserRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email.Trim(),
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            SocialSecurityNumber = request.SocialSecurityNumber.Trim(),
            Email = request.Email.Trim()
        };

        string password = "Secret#1";

        // TODO: Skapa användaren i databasen (ASP.NET Core Identity)
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new Exception("Unable to create user");
        }

        await _userManager.AddToRoleAsync(user, Roles.Customer);

        return new CreateUserResult(UserId: user.Id);
    }
    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new Exception("User not found");

        return new UserDto(
            UserId: userId,
            Email: user.Email!,
            FullName: $"{user.FirstName} {user.LastName}"
        );
    }
}
