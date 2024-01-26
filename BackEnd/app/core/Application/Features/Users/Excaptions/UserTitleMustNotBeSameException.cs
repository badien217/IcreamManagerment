using Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Excaptions
{
    public class UserTitleMustNotBeSameException : BaseException
    {
        public UserTitleMustNotBeSameException() : base("exception!!!") { }
    }
}
