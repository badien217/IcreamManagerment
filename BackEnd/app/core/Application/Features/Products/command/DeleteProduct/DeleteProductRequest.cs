﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.command.DeleteProduct
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public int ProductId { get; set; }
    }
}
