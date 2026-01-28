namespace BankRUs.Application.Identity
{
    public record UserDto(
    Guid UserId,
    string Email,
    string FullName
);
}
