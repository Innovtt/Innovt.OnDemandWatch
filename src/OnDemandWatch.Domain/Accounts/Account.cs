using System.ComponentModel.DataAnnotations;
using Innovt.Core.Exceptions;
using Innovt.Core.Utilities;
using Innovt.Core.Validation;
using Innovt.Domain.Core.Model;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Accounts;

public class Account : IAggregateRoot<Guid>, IValidatableObject
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<User>? Users { get; set; }
    public List<CloudAccount>? Accounts { get; set; }

    public void AddCloudAccount(string accountId, string accountName, CloudProvider provider)
    {
        if (accountId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(accountId));
        if (accountName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(accountName));
        if (provider == null) throw new ArgumentNullException(nameof(provider));
        
        Accounts ??= new List<CloudAccount>();

        var exist = Accounts.Any(a => a.Id == accountId);

        if (exist) throw new BusinessException($"Cloud account already exists.");
        
        var account = CloudAccountFactory.Create(accountId, accountName, provider);
        
        account.EnsureIsValid();

        Accounts.Add(account);
    }

    public void AddUser(string email, string name)
    {
        if (email.IsNullOrEmpty()) throw new ArgumentNullException(nameof(email));
        if (name.IsNullOrEmpty()) throw new ArgumentNullException(nameof(name));
        
        Users??= new List<User>();

        var exist = Users.Any(u => u.Email == email);

        if(exist)
            throw new BusinessException($"User with e-mail {email} already added.");

        var user = new User() { FirstName = name, Email = email };

        user.EnsureIsValid();

        Users.Add(user);
    }
    internal Account()
    {
        
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id.IsGuidEmpty())
            yield return new ValidationResult("Id can't be empty", new[] { nameof(Id)});


        if (Name.IsNullOrEmpty())
            yield return new ValidationResult("Name can't be null or empty", new[] { nameof(Name) });

    }
}