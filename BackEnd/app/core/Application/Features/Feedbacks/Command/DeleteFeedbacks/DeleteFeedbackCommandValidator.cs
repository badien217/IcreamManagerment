using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.DeleteFeedbacks
{
    public class DeleteFeedbackCommandValidator : AbstractValidator<DeleteFeedbackCommandRequest>
    {
        public DeleteFeedbackCommandValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
