using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.command.DeleteBook
{
    public class DeleteBookCommandRequest : IRequest<Unit>
    {
        public int Id { get; internal set; }
    }
}
