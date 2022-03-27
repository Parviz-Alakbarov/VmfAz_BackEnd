using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ProductValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessMotor;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        //[AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        [CacheRemoveAspect("IProductImageService.Get")]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> Add(int productId, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                await CheckIfProductImageLimitExceeded(productId));
            if (result != null)
                return result;

            var imageResult = FileHelper.Upload("Products",file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            ProductImage productImage = new ProductImage
            {
                ProductId = productId,
                ImagePath = imageResult.Message,
                UploadDate = DateTime.Now
            };
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAddedSuccessfully);
        }


        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        [CacheRemoveAspect("IProductImageService.Get")]
        public async Task<IResult> Delete(ProductImage productImage)
        {
            ProductImage deletedImage = await _productImageDal.Get(x => x.Id == productImage.Id);
            if (deletedImage == null)
            {
                return new ErrorResult(Messages.ProductImageNotFound);
            }

            var deleteResult = FileHelper.Delete("images/Products/"+productImage.ImagePath);
            if (!deleteResult.Success)
            {
                return new ErrorResult(Messages.ErrorDeletingImage);
            }
            _productImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.ProductimageDeletedSuccessfully);
        }


        [CacheAspect(15)]
        public async Task<IDataResult<List<ProductImage>>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(await _productImageDal.GetAll(), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<ProductImage>> GetById(int imageId)
        {
            var result = await _productImageDal.Get(x => x.Id == imageId);
            if (result == null)
            {
                return new ErrorDataResult<ProductImage>(Messages.ProductImageNotFound);
            }
            return new SuccessDataResult<ProductImage>(result);
        }

        public async Task<IDataResult<List<ProductImage>>> GetProductImages(int productId)
        {
            var result = await _productImageDal.GetAll(p => p.ProductId == productId);
            return new SuccessDataResult<List<ProductImage>>(result.Count == 0 ?
                (new List<ProductImage>
                {
                    new ProductImage
                    {
                        ProductId = productId,
                        ImagePath = "images/default.jpg",
                        UploadDate = DateTime.Now
                    }
                })
                : result);
        }

        public async Task<IResult> Update(ProductImage productImage, IFormFile file)
        {
            var image = await _productImageDal.Get(x => x.Id == productImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductImageNotFound);
            }
            var updateResult = FileHelper.Update("Products",file, image.ImagePath);
            if (!updateResult.Success)
            {
                return new ErrorResult(updateResult.Message);
            }
            image.ImagePath = updateResult.Message;
            image.UploadDate = DateTime.Now;
            _productImageDal.Update(image);

            return new SuccessResult(Messages.ProductImageUpdatedSuccessfully);
        }

        //Business Rules
        private async Task<IResult>CheckIfProductImageLimitExceeded(int productId)
        {
            var result = (await _productImageDal.GetAll(p => p.ProductId == productId)).Count;
            if (result > 5)
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            return new SuccessResult();
        }

        private async Task<IResult> CheckIfProdcutImageIdExist(int productImageId)
        {
            ProductImage image = (await _productImageDal.Get(i => i.Id == productImageId));
            if (image == null)
                return new ErrorResult(Messages.ProductImageNotFound);
            return new SuccessResult();
        }

    }
}
