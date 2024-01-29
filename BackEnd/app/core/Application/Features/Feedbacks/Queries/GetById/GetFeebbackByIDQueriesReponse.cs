using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Queries.GetById
{
    public class GetFeebbackByIDQueriesReponse 
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime FeedbackDate { get; set; }
        public Feedback Feedback { get; set; }
    }
}
