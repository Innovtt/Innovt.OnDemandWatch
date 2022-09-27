using Innovt.Domain.Core.Model;
using OnDemandWatch.Domain.Accounts;

namespace OnDemandWatch.Domain.Schedules;

public class Schedule : ValueObject<Guid>
{
    public User? CreatedByUser { get; set; }

    public User? UpdatedByUser { get; set; }
    public List<CloudAccount> CloudAccounts { get; set; }
}