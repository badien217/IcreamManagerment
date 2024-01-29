using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Users.command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUsedCommandRequest>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.phone).NotEmpty();
            RuleFor(x => x.SubcriptionType).NotEmpty();
            RuleFor(x => x.PaymentStatus).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
        }
        
    }
}
