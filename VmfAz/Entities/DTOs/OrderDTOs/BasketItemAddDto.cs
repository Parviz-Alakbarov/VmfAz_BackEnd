using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.OrderDTOs
{
    public class BasketItemAddDto : IDto
    {
        public int AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

    }
}
