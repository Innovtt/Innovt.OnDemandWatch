// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

using Innovt.Core.Utilities;
using Innovt.Core.Validation;

namespace OnDemandWatch.Domain.Accounts;

public static class AccountFactory
{
    public static Account Create(string name)
    {
        if (name.IsNullOrEmpty()) throw new ArgumentNullException(nameof(name));

        var account = new Account()
        {
            Id = Guid.NewGuid(),
            Name = name,
        };

        account.EnsureIsValid();

        return account;
    }

}