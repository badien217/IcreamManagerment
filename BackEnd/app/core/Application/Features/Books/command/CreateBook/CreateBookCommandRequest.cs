using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.command.CreateBook
{
    public class CreateBookCommandRequest : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public IFormFile ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int quatity { get; set; }


    }
}
