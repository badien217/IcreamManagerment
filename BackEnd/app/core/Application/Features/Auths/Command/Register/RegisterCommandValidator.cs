using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Fullname)
                .NotEmpty()
                .WithName("Fullname");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithName("Email");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Password");
        }
    }
}
