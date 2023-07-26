using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public string ShippingAddress { get; set; }

        public ICollection<OrderDetail> Details { get; set; }
    }
}
