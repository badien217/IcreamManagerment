using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Steps.Command.UpdateSteps
{
    public class UpdateStepsCommandValidator : AbstractValidator<UpdateStepsCommandRequest>
    {
        public UpdateStepsCommandValidator() {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.RecipeId).NotEmpty();
        }
    }
}
