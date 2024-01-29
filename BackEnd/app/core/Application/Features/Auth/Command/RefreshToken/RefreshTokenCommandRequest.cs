﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<IList<RefreshTokenCommandReponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
