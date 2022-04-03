using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Entities.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSettingDal : ISettingDal
    {
        public async Task<List<Setting>> GetAll()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                return await context.Settings.ToListAsync();
            }
        }

        public async Task<Setting> GetByKey(string key)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from s in context.Settings
                             where s.Key == key
                             select new Setting
                             {
                                 Id = s.Id,
                                 Key = s.Key,
                                 Value = s.Value
                             };
                return await result.SingleOrDefaultAsync();
            }
        }

        public async Task<List<City>> GetCitiesByCountry(int countryId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from c in context.Cities
                             where c.CountryId == countryId
                             select c;
                return await result.OrderBy(x=>x.Name).ToListAsync();
            }
        }

        public async Task<List<Country>> GetCountries()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from c in context.Countries
                             select c;
                return await result.OrderBy(x=>x.Name).ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetGenders()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.Genders
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductFunctionalities()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductFunctionalities
                             select new ProductEntryDto
                             {
                                 Id=f.Id,
                                 Name=f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductWaterResistances()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductWaterResistances
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.ResistanceValue
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductStyles()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductStyles
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             }; 
                return await result.ToListAsync();
            }
        }


        public async Task<List<ProductEntryDto>> GetProductMechanisms()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductMechanisms
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductGlassTypes()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductGlassTypes
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductCaseSizes()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductCaseSizes
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Size
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductCaseShapes()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductCaseShapes
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Shape
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductCaseMaterials()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductCaseMaterials
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<ProductEntryDto>> GetProductBeltTypes()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.ProductBeltTypes
                             select new ProductEntryDto
                             {
                                 Id = f.Id,
                                 Name = f.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<Color>> GetColors()
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from f in context.Colors
                             select f;
                return await result.ToListAsync();
            }
        }


        public async Task Update(Setting setting)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var updateEntity = context.Entry(setting);
                updateEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
