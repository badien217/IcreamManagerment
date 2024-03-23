using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Otp : EntityBase, IEntityBase
    {
        public string name { get; set; }
        public string OtpCode { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpirationTime { get; set; } = DateTime.Now + TimeSpan.FromMinutes(5);
    }
}
