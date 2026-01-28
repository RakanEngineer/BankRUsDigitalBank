namespace BankRUs.Application.Identity;

public interface IIdentityService
{
    Task<CreateUserResult> CreateUserAsync(CreateUserRequest request);
    //Task<UserDto> GetUserByIdAsync(Guid userId);
}
