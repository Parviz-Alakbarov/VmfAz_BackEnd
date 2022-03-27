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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("ISliderService.Get")]
        public IResult Add(SliderPostDto sliderPostDto)
        {
            if (sliderPostDto.File == null)
                return new ErrorResult(Messages.SliderImageIsRequired);

            var uploadResult = FileHelper.Upload("Sliders",sliderPostDto.File);
            if (!uploadResult.Success)
                return new ErrorResult(uploadResult.Message);

            Slider slider = new Slider
            {
                RedirectURL = sliderPostDto.RedirectURL,
                Order = sliderPostDto.Order,
                Image = uploadResult.Message
            };
           _sliderDal.Add(slider);
            return new SuccessResult(Messages.SliderAddedSuccessfully);
        }
        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("ISliderService.Get")]
        public async Task<IResult> Delete(int id)
        {
            Slider slider = await _sliderDal.Get(x => x.Id == id);
            if (slider==null)
            {
                return new ErrorResult(Messages.SliderNotFound);
            }
            _sliderDal.Delete(slider);
            return new SuccessResult(Messages.SliderDeletedSuccessfully);
        }
        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("ISliderService.Get")]
        public async Task<IResult> Update(int id, SliderPostDto sliderPostDto)
        {
            Slider slider = await _sliderDal.Get(x => x.Id == id);
            if (slider == null)
            {
                return new ErrorResult(Messages.SliderNotFound);
            }
            if (sliderPostDto.File != null)
            {
                var fileUpload = FileHelper.Update("Sliders", sliderPostDto.File, slider.Image);
                if (!fileUpload.Success)
                {
                    return new ErrorResult(fileUpload.Message);
                }
                slider.Image = fileUpload.Message;
            }
            slider.Order = sliderPostDto.Order;
            slider.RedirectURL = sliderPostDto.RedirectURL;
            _sliderDal.Update(slider);
            return new SuccessResult(Messages.SliderUpdatedSuccessfully);
        }

        [CacheAspect]
        public async Task<IDataResult<List<Slider>>> GetAll()
        {
            return new SuccessDataResult<List<Slider>>((await _sliderDal.GetAll()).OrderBy(x=>x.Order).ToList());   
        }
    
        public async Task<IDataResult<Slider>> GetById(int id)
        {
            Slider slider = await _sliderDal.Get(x => x.Id == id);
            if (slider == null)
            {
                return new ErrorDataResult<Slider>(Messages.SliderNotFound);
            }
            return new SuccessDataResult<Slider>(slider);
        }
    }
}
