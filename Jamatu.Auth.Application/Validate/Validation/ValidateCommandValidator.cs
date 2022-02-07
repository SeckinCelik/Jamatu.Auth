using FluentValidation;
using Jamatu.Auth.Application.Validate.Command;

namespace Jamatu.Auth.Application.Validate
{
    public class ValidateCommandValidator : AbstractValidator<ValidateCommand>
    {
        public ValidateCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
