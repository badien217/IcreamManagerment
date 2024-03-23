using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Books.command.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommandReuquest>
    {
        public UpdateBookCommandValidator() {
            
        } 
    }
}
