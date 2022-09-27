using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.Accounts;

public class Account : IAggregateRoot<Guid>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public List<User>? Users { get; set; }
    public List<CloudAccount>? Accounts { get; set; }

    public void AddCloudAccount()
    {

    }

    public void Adduser()
    {


    }
}