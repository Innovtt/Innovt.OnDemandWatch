using Innovt.Core.Utilities;

namespace OnDemandWatch.Domain.Accounts;

public class CloudProvider : ConstantClass
{
    private static readonly Lazy<List<CloudProvider>> Providers = new();

    public static readonly CloudProvider Aws = new(1, "Amazon Web Services");
    public static readonly CloudProvider Azure = new(2, "Windows Azure");
    public static readonly CloudProvider Gcp = new(3, "Google Cloud");

    public int Id { get; set; }

    protected CloudProvider(int id, string value) : base(value)
    {
        Id = id;
        Providers.Value.Add(this);
    }
    
    public static CloudProvider? GetByName(string statusName)
    {
        return Providers?.Value.SingleOrDefault(s => s.Value == statusName);
    }

    public static CloudProvider? GetById(int statusId)
    {
        return Providers?.Value.SingleOrDefault(s => s.Id == statusId);
    }
}