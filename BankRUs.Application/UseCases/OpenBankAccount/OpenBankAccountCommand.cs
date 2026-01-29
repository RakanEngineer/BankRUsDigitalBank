using System;
using System.Collections.Generic;
using System.Text;

namespace BankRUs.Application.UseCases.OpenBankAccount
{
    public sealed record OpenBankAccountCommand(Guid UserId);
}
