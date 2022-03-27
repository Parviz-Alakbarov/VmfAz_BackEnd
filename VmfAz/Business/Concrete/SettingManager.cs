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
using Entities.DTOs;
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

            _settingDal.Update(setting);
            return new SuccessResult(Messages.SettingUpdated);
        }
    }
}
