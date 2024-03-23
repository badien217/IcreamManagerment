using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.iceCream.Command.CreateIceCream
{
    public class CreateIceCreamCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public int Flavorld { get; set; }
        public IFormFile ImageUrl { get; set; }
        public ICollection<Flavor> Flavor { get; set; }
    }
}
