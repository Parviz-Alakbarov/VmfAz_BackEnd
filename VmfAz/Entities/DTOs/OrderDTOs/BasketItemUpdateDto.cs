using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OrderDTOs
{
    public class BasketItemUpdateDto : IDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
