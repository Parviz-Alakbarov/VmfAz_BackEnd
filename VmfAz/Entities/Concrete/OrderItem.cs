using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int DiscountPercent { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
