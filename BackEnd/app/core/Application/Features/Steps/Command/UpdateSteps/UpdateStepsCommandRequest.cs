using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Steps.Command.UpdateSteps
{
    public class UpdateStepsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int RecipeId { get; set; }

    }
}
