// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.CloudProviders;

public class ServiceType:ValueObject<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }


    public ServiceType()
    {
        
    }
    
    public ServiceType(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
}