using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.command.DeleteUser
{
    public class DeleteUserCommandValidator :AbstractValidator<DeleteUserCommandRequest>
    {
        public DeleteUserCommandValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
