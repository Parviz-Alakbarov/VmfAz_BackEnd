﻿using Core.DataAccess.EntityFramework;
using Core.Utilities.PaginationHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, VmfAzContext>, IProductDal
    {

        public async Task<ProductDetailDto> GetProductDetails(int id)
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
                             join beltType in context.ProductBeltTypes on p.ProductBeltTypeId equals beltType.Id
                             join caseSize in context.ProductCaseSizes on p.ProductCaseSizeId equals caseSize.Id
                             join beltcolor in context.Colors on p.ProductBeltColorId equals beltcolor.Id
                             join dialcolor in context.Colors on p.ProductDialColorId equals dialcolor.Id
                             where p.Id == id && p.IsDeleted == false
                             select new ProductDetailDto
                             {
                                 Id = id,
                                 Name = p.Name,
                                 PosterImage = p.PosterImage,
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
                                 DiscountedPrice = p.SalePrice * (1 - (decimal)p.DiscountPercent / 100),
                                 DiscountPercent = p.DiscountPercent,
                                 SalePrice = p.SalePrice,
                                 ToolCount = p.ToolCount,
                                 WarrantyLimit = p.WarrantyLimit,
                             };
                return await result.SingleOrDefaultAsync();
            }
        }

        public async Task<List<ProductGetDto>> GetProductsInGetDto(int? count, Expression<Func<ProductGetDto, bool>> expression)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from p in context.Products
                             where p.IsDeleted == false
                             select new ProductGetDto
                             {
                                 Id = p.Id,
                                 DiscountPersent = p.DiscountPercent,
                                 Image = p.PosterImage,
                                 Name = p.Name,
                                 SalePrice = p.SalePrice,
                                 BrandId = p.BrandId,
                                 CreateDate = p.CreateDate,
                                 GenderId = p.GenderId,
                                 ProductFunctionalityId = p.ProductFunctionalityId,
                             };
                if (expression != null)
                   result = result.Where(expression);

                if (count!=null)
                    result = result.Take((int)count);

                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductGetDto>>GetBestSellerProducts(int count, Expression<Func<ProductGetDto, bool>> expression)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var firstQuery = from o in context.OrderItems
                                 group o.Count by o.ProductId into g
                                 orderby g.Sum() descending
                                 select g.Key ;

                var idArr =  firstQuery.Take(count).ToList();


                var result = from p in context.Products
                             where p.IsDeleted == false &&  idArr.Contains(p.Id)
                             select new ProductGetDto
                             {
                                 Id = p.Id,
                                 DiscountPersent = p.DiscountPercent,
                                 Image = p.PosterImage,
                                 Name = p.Name,
                                 SalePrice = p.SalePrice,
                                 BrandId = p.BrandId,
                                 CreateDate = p.CreateDate,
                                 GenderId = p.GenderId,
                                 ProductFunctionalityId = p.ProductFunctionalityId,
                             };
                return expression == null ? await result.ToListAsync() : await result.Where(expression).ToListAsync();
            }
        }


        public async Task<PaginationList<ProductGetDto>> GetProductsPaginated(UserParams userParams)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var query = (from p in context.Products
                             where p.IsDeleted == false
                             select new ProductGetDto
                             {
                                 Id = p.Id,
                                 DiscountPersent = p.DiscountPercent,
                                 Image = p.PosterImage,
                                 Name = p.Name,
                                 SalePrice = p.SalePrice,
                                 BrandId = p.BrandId,
                                 CreateDate = p.CreateDate,
                                 GenderId = p.GenderId,
                                 ProductFunctionalityId = p.ProductFunctionalityId,
                             }).AsNoTracking();
                return await PaginationList<ProductGetDto>.CreateAsync(query,userParams.PageNumber,userParams.PageSize);
            }
        }

    }
}
