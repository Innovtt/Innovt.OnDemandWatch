using System.ComponentModel.DataAnnotations;
using Innovt.Core.Collections;
using Innovt.Core.Exceptions;
using Innovt.Core.Utilities;
using Innovt.Domain.Core.Model;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Accounts;

public class CloudAccount : Entity, IValidatableObject
{
    public new string? Id { get; set; }
    public string? Name { get; set; }
    public string? Region { get; set; }
    public string? RoleArn { get; set; }
    public CloudProvider? CloudProvider { get; set; }
    public List<Service>? Services { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    
    internal CloudAccount()
    {
    }
    
    public void AddResource()
    {

    }

    public void RemoveResource(Guid resourceId)
    {
    }
    
    public void AddTag(string key, string value)
    {
        if (key.IsNullOrEmpty()) throw new ArgumentNullException(nameof(key));
        if (value.IsNullOrEmpty()) throw new ArgumentNullException(nameof(value));
        
        Tags ??=new Dictionary<string, string>();

        if (Tags.ContainsKey(key))
            throw new BusinessException($"Key {key} already exist.");

        Tags.Add(key, value);
    }

    public void RemoveTag(string key)
    {
        if (key.IsNullOrEmpty()) throw new ArgumentNullException(nameof(key));
        
        Tags ??= new Dictionary<string, string>();

        if (!Tags.ContainsKey(key))
            throw new BusinessException($"Key {key} doesn't exist.");

        Tags.Remove(key);
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id.IsNullOrEmpty())
            yield return new ValidationResult("Id can't be null or empty", new[] { nameof(Id) });

        if (Name.IsNullOrEmpty())
            yield return new ValidationResult("Name can't be null or empty", new[] { nameof(Name) });

        if (CloudProvider is null)
            yield return new ValidationResult("CloudProvider can't be null.", new[] { nameof(CloudProvider) });
    }
}