using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Command.CreateFeedbacks
{
    public class CreateFeedbackCommandRequest : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
