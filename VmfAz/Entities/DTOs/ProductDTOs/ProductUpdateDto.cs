using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductUpdateDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountPercent { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }

        public IFormFile PosterImage { get; set; }
    }
}
