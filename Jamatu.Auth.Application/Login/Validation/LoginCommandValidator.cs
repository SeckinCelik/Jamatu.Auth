using FluentValidation;
using Jamatu.Auth.Application.Login.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jamatu.Auth.Application.Login.Validation
{
    public class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c =>c.Username).NotEmpty();
            RuleFor(c =>c.Password).NotEmpty();
        }
    }
}
