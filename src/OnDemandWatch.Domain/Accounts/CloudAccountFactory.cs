// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

using Innovt.Core.Utilities;
using Innovt.Core.Validation;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Accounts;

public static class CloudAccountFactory
{
    public static CloudAccount Create(string accountId, string accountName, CloudProvider provider)
    {
        if (accountId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(accountId));
        if (accountName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(accountName));
        if (provider == null) throw new ArgumentNullException(nameof(provider));

        var account = new CloudAccount()
        {
            Id = accountId,
            Name = accountName,
            CloudProvider = provider,
            CreatedAt = DateTimeOffset.UtcNow
        };

        account.EnsureIsValid();

        return account;
    }

}