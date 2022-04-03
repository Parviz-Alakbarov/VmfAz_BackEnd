using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Entities.DTOs;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SettingManager : ISettingService
    {
        private readonly ISettingDal _settingDal;

        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }

        [CacheAspect]
        public async Task<IDataResult<List<Setting>>> GetAll()
        {
            return new SuccessDataResult<List<Setting>>(await _settingDal.GetAll(), Messages.SettingListed);
        }

        public async Task<IDataResult<Setting>> GetByKey(string key)
        {
            var result = await _settingDal.GetByKey(key);
            if (result == null)
            {
                return new ErrorDataResult<Setting>(Messages.SettingDataNotFound);
            }
            return new SuccessDataResult<Setting>(result, Messages.SettingListed);
        }

        public async Task<IDataResult<List<Country>>> GetCountries()
        {
            return new SuccessDataResult<List<Country>>(await _settingDal.GetCountries(), Messages.CountriesListed);
        }

        public async Task<IDataResult<List<City>>> GetCitiesByCountry(int countryId)
        {
            var result = await _settingDal.GetCitiesByCountry(countryId);
            if (result == null)
            {
                return new ErrorDataResult<List<City>>(Messages.CityNotExist);
            }
            return new SuccessDataResult<List<City>>(result, Messages.CitiesListed);
        }

        [AuthorizeOperation("SuperAdmin,Admin")]
        [CacheRemoveAspect("ISettingService.Get")]
        public async Task<IResult> Update(SettingPostDto settingPostDto)
        {
            Setting setting = await _settingDal.GetByKey(settingPostDto.Key);
            if (setting == null)
                return new ErrorResult(Messages.SettingDataNotFound);
            if (settingPostDto.File == null)
            {
                setting.Value = settingPostDto.Value;
            }
            else
            {
                var uploadResult = FileHelper.Update("Settings", settingPostDto.File, setting.Value);
                if (!uploadResult.Success)
                {
                    return new ErrorResult(uploadResult.Message);
                }
                setting.Value = uploadResult.Message;
            }

            await _settingDal.Update(setting);
            return new SuccessResult(Messages.SettingUpdated);
        }

        public async Task<IDataResult<List<ProductEntryDto>>> GetProductFuntionalities()
        {
            return new SuccessDataResult<List<ProductEntryDto>> (await _settingDal.GetProductFunctionalities(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductBeltTypes()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductBeltTypes(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductCaseMaterials()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductCaseMaterials(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductCaseShapes()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductCaseShapes(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductCaseSizes()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductCaseSizes(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductGlassTypes()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductGlassTypes(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductMechanisms()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductMechanisms(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductStyles()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductStyles(), Messages.EntriesListed);
        }
        public async Task<IDataResult<List<ProductEntryDto>>> GetProductWaterResistances()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetProductWaterResistances(), Messages.EntriesListed);
        }

        public async Task<IDataResult<List<ProductEntryDto>>> GetGenders()
        {
            return new SuccessDataResult<List<ProductEntryDto>>(await _settingDal.GetGenders(), Messages.EntriesListed);
        }

        public async Task<IDataResult<List<Color>>> GetColors()
        {
            return new SuccessDataResult<List<Color>>(await _settingDal.GetColors(), Messages.ColorsListed);
        }
    }
}
