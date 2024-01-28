using Application.Bases;
using Application.Features.Users.Excaptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.UserRule
{
    public class UserRules : BaseRule
    {
        public Task UserTitleMostNotBeSame(IList<User> users ,string requestTitle)
        {
            if (users.Any(x => x.Username == requestTitle)) throw new UserTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
