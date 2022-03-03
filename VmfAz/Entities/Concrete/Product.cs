using Core.Entities;
using Entities.Concrete.ProductEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public int ProductFunctionalityId { get; set; }
        public int? ToolCount { get; set; }
        public decimal WarrantyLimit { get; set; }//decimal(3,1)
        public int? ProductStyleId { get; set; }
        public int? ProductWaterResistanceId { get; set; }
        public int? ProductProductionCountryId { get; set; }
        public int? ProductMechanismId { get; set; }
        public int? ProductGlassTypeId { get; set; }
        public int? ProductCaseMaterialId { get; set; }
        public int? ProductCaseShapeId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public Brand Brand { get; set; }
        public List<ProductEntry> ProductEntries { get; set; }
        public Gender Gender { get; set; }
        public ProductStyle ProductStyle { get; set; }
        public ProductWaterResistance ProductWaterResistance { get; set; }
        public ProductProductionCountry ProductProductionCountry { get; set; }
        public ProductMechanism ProductMechanism { get; set; }
        public ProductGlassType ProductGlassType { get; set; }
        public ProductCaseShape ProductCaseShape { get; set; }
        public ProductCaseMaterial ProductCaseMaterial { get; set; }
    }

}
