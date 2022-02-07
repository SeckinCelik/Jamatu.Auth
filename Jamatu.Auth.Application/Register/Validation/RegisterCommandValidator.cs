using FluentValidation;
using Jamatu.Auth.Application.Register.Command;

namespace Jamatu.Auth.Application.Register.Validation
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
