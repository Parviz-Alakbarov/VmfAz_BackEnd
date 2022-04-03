using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OrderDTOs
{
    public class OrderUpdateDto : IDto
    {
        public int OrderId { get; set;}
        public OrderStatus OrderStatus { get; set;}
    }
}
