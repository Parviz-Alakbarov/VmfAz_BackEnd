using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ShopPostDto : IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Address { get; set; }
        public byte OpenHour { get; set; }
        public byte CloseHour { get; set; }
        public byte OpenMinute { get; set; }
        public byte CloseMinute { get; set; }
        public string RedirectUrl { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
