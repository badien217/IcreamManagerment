using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookOrderDetail : IEntityBase
    {
        public int BookId { get; set; }
        public int OrderDetailId { get; set; }
        public Book book { get; set; }
        public OrderDetail order { get; set; }
    }
}
