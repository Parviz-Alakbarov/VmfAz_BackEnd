using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BasketItem : IEntity
    {
        public int Id { get; set; } 
        public int AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }

        public AppUser AppUser { get; set; }
        public Product Product { get; set; }

    }
}
