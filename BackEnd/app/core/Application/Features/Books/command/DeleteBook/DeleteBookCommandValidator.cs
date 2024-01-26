using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.command.DeleteBook
{
    public class DeleteBookCommandValidator :AbstractValidator<DeleteBookCommandRequest>
    {
        public DeleteBookCommandValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }

    }
}
