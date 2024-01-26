using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.command.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest
    {
        public int Id { get; set; } 
    }
}
