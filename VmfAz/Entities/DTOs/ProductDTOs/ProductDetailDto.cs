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
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterImage { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; } 
        public string Gender { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string Style { get; set; }
        public string Mechanism { get; set; }
        public string GlassType { get; set; }
        public string WaterResistance { get; set; }
        public decimal WarrantyLimit { get; set; }
        public string ProductionCountry { get; set; }
        public string CaseShape { get; set; }
        public string CaseMaterial { get; set; }
        public int? ToolCount { get; set; }

        public string CaseSize { get; set; }
        public string BeltType { get; set; }
        public string BeltColor { get; set; }
        public string DialColor { get; set; }




    }
}
