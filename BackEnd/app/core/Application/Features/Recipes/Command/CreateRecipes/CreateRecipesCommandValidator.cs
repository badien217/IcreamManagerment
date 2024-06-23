using Application.Features.Feedbacks.Command.CreateFeedbacks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Recipes.Command.CreateRecipes
{
    public class CreateRecipesCommandValidator : AbstractValidator<CreateRecipesCommandRequest>
    {
        public CreateRecipesCommandValidator() {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            
            RuleFor(x => x.SubMittedBy).NotEmpty();
            RuleFor(x => x.Ingredients).NotEmpty();

        }
    }
}
