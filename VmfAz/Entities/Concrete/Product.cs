using Core.Entities;
using Core.Entities.Concrete;
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
        public string PosterImage { get; set; }
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
        public int? ProductCaseSizeId { get; set; }
        public int? ProductBeltTypeId { get; set; }
        public int? ProductBeltColorId { get; set; }
        public int? ProductDialColorId { get; set; }


        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public Brand Brand { get; set; }
        public Gender Gender { get; set; }
        public ProductStyle ProductStyle { get; set; }
        public ProductWaterResistance ProductWaterResistance { get; set; }
        public ProductMechanism ProductMechanism { get; set; }
        public ProductGlassType ProductGlassType { get; set; }
        public ProductCaseShape ProductCaseShape { get; set; }
        public ProductCaseMaterial ProductCaseMaterial { get; set; }
        public Country Country { get; set; }
        public ProductBeltType ProductBeltType { get; set; }
        public ProductCaseSize ProductCaseSize { get; set; }
        public Color ProductDialColor { get; set; }
        public Color ProductBeltColor { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<ProductShop> ProductShops { get; set; }
    }

}
