using Innovt.Domain.Core.Model;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Accounts;

public class CloudAccount : Entity<Guid>
{
    public string? Name { get; set; }

    public string? Region { get; set; }

    public string? RoleArn { get; set; }// authorization type.  per provider

    public CloudProvider? CloudProvider { get; set; }
    public List<Service>? Resources { get; set; } //Conta Amazon com os resources x e y. 
    public Dictionary<string, string>? Tags { get; set; }

    public void AddResource()
    {

    }

    public void RemoveResource(Guid resourceId)
    {
    }



    public void AddTag(string key, string value)
    {

    }



    public void RemoveTag(string key)
    {

    }




    //utilizar uma tag para criar o environmento por conta ou por resource ? 




    //em uma mesma conta pode ter diferentes environments ? Sim 



}