using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.iceCream.Command.UpdateIceCream
{
    public class UpdateIceCreamCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Flavorld { get; set; }
        public IFormFile ImageUrl { get; set; }

    }
}
