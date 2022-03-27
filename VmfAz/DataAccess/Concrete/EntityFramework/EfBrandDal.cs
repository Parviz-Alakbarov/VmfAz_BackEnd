using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, VmfAzContext>, IBrandDal
    {
        public async Task<BrandDetailDto> GetBrandDetail(int id)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from brand in context.Brands
                             where brand.Id == id
                             select new BrandDetailDto
                             {
                                 Id = brand.Id,
                                 Description = brand.Description,
                                 Image = brand.Image,
                                 Name = brand.Name,
                                 PosterImage  = brand.PosterImage,
                             };
                return await result.SingleOrDefaultAsync();
            }
        }

        public async Task<List<BrandWithNameDto>> GetBrandsOnlyWithName()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from brand in context.Brands
                             select new BrandWithNameDto
                             {
                                 Id = brand.Id,
                                 Name = brand.Name,
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<BrandWithImageDto>> GetBrandsWithImage()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from brand in context.Brands
                             select new BrandWithImageDto
                             {
                                 Id = brand.Id,
                                 Name = brand.Name,
                                 Image = brand.Image
                             };
                return await result.ToListAsync();
            }
        }
    }
}
