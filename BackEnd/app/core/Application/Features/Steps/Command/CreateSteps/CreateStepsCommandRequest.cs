using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Steps.Command.CreateSteps
{
    public class CreateStepsCommandRequest : IRequest<Unit>
    {
        public string Content { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int RecipeId { get; set; }

    }
}
