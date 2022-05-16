using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductGetDtoAdmin : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public bool IsDeleted { get; set; } 
        public int DiscountPersent { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
