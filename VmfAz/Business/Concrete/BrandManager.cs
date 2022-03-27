using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.BrandValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessMotor;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        [AuthorizeOperation("SuperAdmin")]
        [ValidationAspect(typeof(BrandPostDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get")]
        public async Task<IResult> Add(BrandPostDto brandPostDto)
        {
            IResult result = BusinessRules.Run(
               CheckIfBrandExistWithName(brandPostDto.Name));

            if (result != null)
                return result;
            Brand brand = new Brand()
            {
                Name = brandPostDto.Name,
                Description = brandPostDto.Description
            };
            var uploadResult = UploadPhotos(brandPostDto.Image, brandPostDto.PosterImage);
            if (!uploadResult.Success)
            {
                return new ErrorResult(uploadResult.Message);
            }
            brand.Image = uploadResult.Data[0];
            brand.PosterImage = uploadResult.Data[1];

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }


        [AuthorizeOperation("SuperAdmin")]
        [ValidationAspect(typeof(BrandPostDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get")]
        public async Task<IResult> Update(int id, BrandPostDto brandPostDto)
        {
            IResult result = BusinessRules.Run(
              CheckIfBrandExistWithName(brandPostDto.Name));

            if (result != null)
                return result;

            Brand brand = await _brandDal.Get(x => !x.IsDeleted && x.Id == id);
            if (brand == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            brand.Description = brandPostDto.Description;
            brand.Name = brandPostDto.Name;

            if (brandPostDto.Image.FileName != brand.Image)
            {
                var imageResult = FileHelper.Update("Brands", brandPostDto.Image, brandPostDto.Image.FileName);
                if (!imageResult.Success)
                    return new ErrorResult(imageResult.Message);
                brand.Image = imageResult.Message;
            }
            if (brandPostDto.PosterImage.FileName != brand.PosterImage)
            {
                var imageResult = FileHelper.Update("Brands", brandPostDto.PosterImage, brand.PosterImage);
                if (!imageResult.Success)
                    return new ErrorResult(imageResult.Message);
                brand.PosterImage = imageResult.Message;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdatedSuccesfully);
        }



        [AuthorizeOperation("SuperAdmin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public async Task<IResult> Delete(int brandId)
        {
            var result = await _brandDal.Get(p => p.Id == brandId);
            if (result == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            result.IsDeleted = true;
            _brandDal.Update(result);
            return new SuccessResult(Messages.BrandDeletedSuccessfully);
        }


        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public async  Task<IResult> UnDelete(int brandId)
        {
            Brand brand = await _brandDal.Get(x => x.Id == brandId);
            if (brand == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            brand.IsDeleted = false;
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUndeletedSuccessfully);
        }


        public async Task<IDataResult<Brand>> GetBrandById(int brandId)
        {
            var result = await _brandDal.Get(p => p.Id == brandId);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<Brand>(result);
        }

        [CacheAspect]
        public async Task< IDataResult<List<Brand>>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(await _brandDal.GetAll(), Messages.BrandsListedSuccessfully);
        }




        public async Task<IDataResult<List<BrandWithNameDto>>> GetBrandsOnlyWithName()
        {
            return new SuccessDataResult<List<BrandWithNameDto>>((await _brandDal.GetBrandsOnlyWithName()), Messages.BrandsListedSuccessfully);
        }

        public async Task<IDataResult<List<BrandWithImageDto>>> GetBrandsWithImage()
        {
            return new SuccessDataResult<List<BrandWithImageDto>>(await _brandDal.GetBrandsWithImage(),Messages.BrandsListedSuccessfully);
        }

        public async Task<IDataResult<BrandDetailDto>> GetBrandDetail(int brandId)
        {
            var result = await _brandDal.GetBrandDetail(brandId);
            if (result == null)
            {
                return new ErrorDataResult<BrandDetailDto>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<BrandDetailDto>(result);
        }



        //Business Rules


        private IDataResult<string[]> UploadPhotos(IFormFile image, IFormFile posterImage)
        {
            var imageResult = FileHelper.Upload("Brands", image);
            if (!imageResult.Success)
            {
                return new ErrorDataResult<string[]>(imageResult.Message);
            }
            var posterImageResult = FileHelper.Upload("Brands", posterImage);
            if (!posterImageResult.Success)
            {
                return new ErrorDataResult<string[]>(posterImageResult.Message);
            }
            string[] imageArray = new string[] { imageResult.Message, posterImageResult.Message };
            return new SuccessDataResult<string[]>(imageArray);

        }

        private IDataResult<string> UploadPhoto(IFormFile image)
        {
            var imageResult = FileHelper.Upload("Brands", image);
            if (!imageResult.Success)
            {
                return new ErrorDataResult<string>(imageResult.Message);
            }
            return new SuccessDataResult<string>(imageResult.Message);
        }




        private IResult CheckIfBrandExistWithName(string name)
        {
            if (_brandDal.Get(p => p.Name == name) != null)
                return new ErrorResult(Messages.BrandAlreadyExists);

            return new SuccessResult();
        }

    }
}
