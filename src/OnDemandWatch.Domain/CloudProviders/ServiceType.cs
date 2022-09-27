using System.Linq.Expressions;
using Innovt.Domain.Core.Model;

namespace OnDemandWatch.Domain.CloudProviders;

public class ServiceType : ValueObject<Guid>
{
    public string? Name { get; set; } //lambda, kinesis, dynamo 

    //tipo de scale 





}