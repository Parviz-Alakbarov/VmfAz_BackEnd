using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductShop : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
        public Product Product { get; set; }
        public Shop Shop { get; set; }
    }
}
