using Core.Entities;
using Core.Entities.Concrete;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int? AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
        public int ShippingTypeId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid OrderTrackId { get; set; }


        public Country Country { get; set; }
        public City City { get; set; }
        public AppUser AppUser { get; set; }
        public ShippingType ShippingType { get; set; }
        public List<OrderItem> OrderItems { get; set;}

    }
}
