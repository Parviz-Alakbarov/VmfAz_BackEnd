using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
        [CacheRemoveAspect("IProductImageService.Get")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(int productId, IFormFile file)
        {
            IResult result = BusinessRules.Run();
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

        public IResult Delete(ProductImage productImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<ProductImage> GetById(int imageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ProductImage productImage, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
