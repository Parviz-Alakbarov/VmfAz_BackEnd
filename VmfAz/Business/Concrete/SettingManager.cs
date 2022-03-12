using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
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
        public IDataResult<List<Setting>> GetAll()
        {
            return new SuccessDataResult<List<Setting>>(_settingDal.GetAll(), Messages.SettingListed);
        }

        public IDataResult<Setting> GetByKey(string key)
        {
            var result = _settingDal.GetByKey(key);
            if (result == null)
            {
                return new ErrorDataResult<Setting>(Messages.SettingDataNotFound);
            }
            return new SuccessDataResult<Setting>(result, Messages.SettingListed);
        }
        [AuthorizeOperation("SuperAdmin,Admin")]
        [CacheRemoveAspect("ISettingService.Get")]
        public IResult Update(SettingPostDto settingPostDto)
        {
            Setting setting = _settingDal.GetByKey(settingPostDto.Key);
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
