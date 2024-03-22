using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.queries.GetById
{
    public class GetByIdCommandRequest : IRequest<GetByIdCommandReponse>
    {
        [DefaultValue(1)]
        public int id {  get; set; }

        
    }
}
