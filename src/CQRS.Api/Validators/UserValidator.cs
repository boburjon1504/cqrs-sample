using CQRS.Api.Domain.Entities;
using FluentValidation;
namespace CQRS.Api.Validators;
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().EmailAddress();
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
    }
}
