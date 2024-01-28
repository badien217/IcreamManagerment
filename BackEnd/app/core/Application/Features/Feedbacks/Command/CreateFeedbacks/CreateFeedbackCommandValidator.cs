using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.CreateFeedbacks
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommandRequest>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.FeedbackContent).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FeedbackDate).NotEmpty();
        }
    }
}
