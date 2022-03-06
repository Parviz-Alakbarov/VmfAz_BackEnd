using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductAddDto : IDto
    {
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public int ProductFunctionalityId { get; set; }
        public int? ToolCount { get; set; }
        public decimal WarrantyLimit { get; set; }//decimal(3,1)
        public int? ProductStyleId { get; set; }
        public int? ProductWaterResistanceId { get; set; }
        public int? CountryId { get; set; }
        public int? ProductMechanismId { get; set; }
        public int? ProductGlassTypeId { get; set; }
        public int? ProductCaseMaterialId { get; set; }
        public int? ProductCaseShapeId { get; set; }


        public int? ProductBeltTypeId { get; set; }
        public int? ProductCaseSizeId { get; set; }
        public int? ProductBeltColorId { get; set; }
        public int? ProductDialColorId { get; set; }


        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
    }
}
