using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public ICollection<ProductCategoryMap> CategoryMap { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
