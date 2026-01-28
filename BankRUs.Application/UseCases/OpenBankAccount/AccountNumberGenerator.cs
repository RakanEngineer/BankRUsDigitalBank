namespace BankRUs.Application.UseCases.OpenBankAccount
{
    public class AccountNumberGenerator
    {
        public static string Generate()
        {
            return $"SE-{Random.Shared.Next(10000000, 99999999)}";
        }
    }
}