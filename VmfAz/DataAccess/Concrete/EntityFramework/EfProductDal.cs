using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, VmfAzContext>, IProductDal
    {

        public ProductDetailDto GetProductDetails(int id)
        {
            using (VmfAzContext context = new())
            {
                var result = from p in context.Products
                             join b in context.Brands on p.BrandId equals b.Id
                             join country in context.Countries on p.CountryId equals country.Id
                             join me in context.ProductMechanisms on p.ProductMechanismId equals me.Id
                             join gender in context.Genders on p.GenderId equals gender.Id
                             join caseMaterial in context.ProductCaseMaterials on p.ProductCaseMaterialId equals caseMaterial.Id
                             join glassType in context.ProductGlassTypes on p.ProductGlassTypeId equals glassType.Id
                             join style in context.ProductStyles on p.ProductStyleId equals style.Id
                             join waterRes in context.ProductWaterResistances on p.ProductWaterResistanceId equals waterRes.Id
                             join caseShape in context.ProductCaseShapes on p.ProductCaseShapeId equals caseShape.Id
                             join pe in context.ProductEntries on p.Id equals pe.ProductId
                             join beltType in context.ProductBeltTypes on pe.ProductBeltTypeId equals beltType.Id
                             join caseSize in context.ProductCaseSizes on pe.ProductCaseSizeId equals caseSize.Id
                             join beltcolor in context.Colors on pe.ProductBeltColorId equals beltcolor.Id
                             join dialcolor in context.Colors on pe.ProductDialColorId equals dialcolor.Id
                             where p.Id == id
                             select new ProductDetailDto
                             {
                                 Name = p.Name,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ProductionCountry = country.Name,
                                 Mechanism = me.Name,
                                 Gender = gender.Name,
                                 CaseMaterial = caseMaterial.Name,
                                 GlassType = glassType.Name,
                                 Style = style.Name,
                                 WaterResistance = waterRes.ResistanceValue,
                                 BeltType = beltType.Name,
                                 BeltColor = beltcolor.Name,
                                 DialColor = dialcolor.Name,
                                 CaseShape = caseShape.Shape,
                                 CaseSize = caseSize.Size,
                                 Description = p.Description,
                                 DiscountedPrice = p.SalePrice*(1-(decimal)p.DiscountPercent/100),
                                 DiscountPercent = p.DiscountPercent,
                                 SalePrice = p.SalePrice,
                                 Image = p.Image,
                                 ToolCount = p.ToolCount,
                                 WarrantyLimit = p.WarrantyLimit,
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
