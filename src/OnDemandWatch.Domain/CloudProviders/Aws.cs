// Innovt Company
// Author: Michel Borges
// Project: OnDemandWatch.Domain

namespace OnDemandWatch.Domain.CloudProviders;

public class Aws:CloudProvider 
{
    public Aws()
    {
        this.Id = new Guid("324ff012-e733-4852-a804-aec9a4c9d9af");
        this.Name = "Amazon Web Services";
    }


    public override List<ServiceType>? GetServiceTypes()
    {
        return new List<ServiceType>()
        {
            new("Lambda", "Function as a service"),
            new("DynamoDB", "Key value database"),
            new("Kinesis Data Stream", "Kinesis Data Stream"),
        };
    }
}