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
        public IResult Add(int productId, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductImageLimitExceeded(productId));
            if (result != null)
                return result;

            var imageResult = FileHelper.Upload(file);
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
        public IResult Delete(ProductImage productImage)
        {
            ProductImage deletedImage = _productImageDal.Get(x => x.Id == productImage.Id);
            if (deletedImage == null)
            {
                return new ErrorResult(Messages.ProductImageNotFound);
            }

            var deleteResult = FileHelper.Delete(productImage.ImagePath);
            if (!deleteResult.Success)
            {
                return new ErrorResult(Messages.ErrorDeletingImage);
            }
            _productImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.ProductimageDeletedSuccessfully);
        }


        [CacheAspect(15)]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(), Messages.ProductsListedSuccessfully);
        }

        public IDataResult<ProductImage> GetById(int imageId)
        {
            var result = _productImageDal.Get(x => x.Id == imageId);
            if (result == null)
            {
                return new ErrorDataResult<ProductImage>(Messages.ProductImageNotFound);
            }
            return new SuccessDataResult<ProductImage>(result);
        }

        public IDataResult<List<ProductImage>> GetProductImages(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
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

        public IResult Update(ProductImage productImage, IFormFile file)
        {
            var image = _productImageDal.Get(x => x.Id == productImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductImageNotFound);
            }
            var updateResult = FileHelper.Update(file, image.ImagePath);
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
        private IResult CheckIfProductImageLimitExceeded(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (result > 5)
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            return new SuccessResult();
        }

        private IResult CheckIfProdcutImageIdExist(int productImageId)
        {
            ProductImage image = _productImageDal.Get(i => i.Id == productImageId);
            if (image == null)
                return new ErrorResult(Messages.ProductImageNotFound);
            return new SuccessResult();
        }

    }
}
