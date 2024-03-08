﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Command.DeleteFaq
{
    public class DeleteFaqRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
