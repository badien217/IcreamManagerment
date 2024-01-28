using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.DeleteFeedbacks
{
    public class DeleteFeedbackCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
