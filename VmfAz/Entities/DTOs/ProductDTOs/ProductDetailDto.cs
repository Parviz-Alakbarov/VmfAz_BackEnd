using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductDetailDto : IDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        //public Gender Gender { get; set; }
    }
}
