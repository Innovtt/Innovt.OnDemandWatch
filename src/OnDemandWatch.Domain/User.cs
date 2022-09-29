using System.ComponentModel.DataAnnotations;
using Innovt.Core.Utilities;
using Innovt.Domain.Users;

namespace OnDemandWatch.Domain
{
    public class User:BaseUser, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.IsNullOrEmpty())
                yield return new ValidationResult("Name can't be null or empty", new[] { nameof(Name) });

            if (Email.IsNullOrEmpty())
                yield return new ValidationResult("Email can't be null or empty", new[] { nameof(Email) });

            if (!Email.IsEmail())
                yield return new ValidationResult("Invalid e-mail address", new[] { nameof(Email) });
        }
    }
}