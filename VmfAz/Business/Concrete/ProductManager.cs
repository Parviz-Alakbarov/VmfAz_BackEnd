using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ProductValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessMotor;
using Core.Utilities.FileHelper;
using Core.Utilities.PaginationHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IBrandService _brandService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper, ICountryService countryService, IBrandService brandService)
        {
            _productDal = productDal;
            _mapper = mapper;
            _countryService = countryService;
            _brandService = brandService;
        }
        //[AuthorizeOperation("SuperAdmin")]
        [ValidationAspect(typeof(ProductAddDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> Add(ProductAddDto productAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckCountryExist(productAddDto.CountryId),
                await CheckIfProductExistWithName(productAddDto.Name));

            if (result != null)
                return result;

            var posterImageResult = FileHelper.Upload("Products", productAddDto.PosterImage);
            if (!posterImageResult.Success)
                return new ErrorResult(posterImageResult.Message);

            Product product = _mapper.Map<Product>(productAddDto);
            product.PosterImage = posterImageResult.Message;
            await _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ProductUpdateDtoValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> Update(int id, ProductUpdateDto productUpdateDto)
        {
            IResult result = BusinessRules.Run(
                await CheckIfProductExistWithName(productUpdateDto.Name));
            if (result != null)
                return result;

            Product product = await _productDal.Get(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            if (productUpdateDto.PosterImage != null)
            {
                var imageUploadResult = FileHelper.Update("Products", productUpdateDto.PosterImage, product.PosterImage);
                if (!imageUploadResult.Success)
                    return new ErrorResult(imageUploadResult.Message);
                product.PosterImage = imageUploadResult.Message;
            }

            product.CostPrice = productUpdateDto.CostPrice;
            product.SalePrice = productUpdateDto.SalePrice;
            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.DiscountPercent = productUpdateDto.DiscountPercent;

            await _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdatedSuccesfully);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> Delete(int productId)
        {
            Product product = await _productDal.Get(x => x.Id == productId && !x.IsDeleted);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.IsDeleted = true;
            await _productDal.Update(product);
            return new SuccessResult(Messages.ProductDeletedSuccessfully);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public async Task<IResult> UnDelete(int productId)
        {
            Product product = await _productDal.Get(x => x.Id == productId && x.IsDeleted);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.IsDeleted = false;
            await _productDal.Update(product);
            return new SuccessResult(Messages.ProductUndeletedSuccessfully);
        }

        [CacheAspect(15)]
        public async Task<IDataResult<List<Product>>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAll(x => !x.IsDeleted), Messages.ProductsListedSuccessfully);
        }
        public async Task<IDataResult<Product>> GetProductById(int productId)
        {
            var result = await _productDal.Get(p => p.Id == productId && !p.IsDeleted);
            if (result == null)
            {
                return new ErrorDataResult<Product>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<Product>(result);
        }
        public async Task<IDataResult<ProductDetailDto>> GetProductDetils(int id)
        {
            var result = await _productDal.GetProductDetails(id);
            if (result == null)
            {
                return new ErrorDataResult<ProductDetailDto>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<ProductDetailDto>(result);
        }

        public async Task<IDataResult<List<ProductGetDto>>> GetProductsByBrandId(int brandId)
        {
            IResult businessResult = BusinessRules.Run( await CheckIfBrandExistsById(brandId));
            if (businessResult != null)
                return new ErrorDataResult<List<ProductGetDto>>(businessResult.Message);

            var result = await _productDal.GetProductsInGetDto(null, x => x.BrandId == brandId);
            if (result == null)
            {
                return new ErrorDataResult<List<ProductGetDto>>(Messages.ProductNotFound);
            }

            return new SuccessDataResult<List<ProductGetDto>>(result);
        }

        public async Task<IDataResult<List<ProductGetDto>>> SearchProducts(string name)
        {
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetProductsInGetDto(null, x => x.Name.IndexOf(name) != -1   ));
        }

        [CacheAspect]
        public async Task<IDataResult<List<ProductGetDto>>> GetProductsInGetDto()
        {
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetProductsInGetDto(), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<List<ProductGetDto>>> GetBestSellerProducts(int count)
        {
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetBestSellerProducts(count), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<List<ProductGetDto>>> GetBestSellerProductsByBrandId(int brandId, int count)
        {
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetBestSellerProducts(count, x => x.BrandId == brandId), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<List<ProductGetDto>>> GetDiscountedProducts(int? count)
        {
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetProductsInGetDto(count, x => x.DiscountPersent > 0), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<PaginationList<ProductGetDto>>> GetProductsPagination(UserParams userParams)
        {
            return new SuccessDataResult<PaginationList<ProductGetDto>>(await _productDal.GetProductsPaginated(userParams), Messages.ProductsListedSuccessfully);
        }

        public async Task<IDataResult<List<ProductGetDto>>> GetRelatedProducts(int productId)
        {
            var result = await _productDal.GetProductsInGetDto(1, x => x.Id == productId);
            if (result == null)
            {
                return new ErrorDataResult<List<ProductGetDto>>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<List<ProductGetDto>>(await _productDal.GetProductsInGetDto(5, x => x.BrandId == result[0].BrandId && x.Id != productId));
        }




        //Business Rules
        private IResult CheckCountryExist(int? countryId)
        {
            if (countryId == null)
            {
                return new SuccessResult();
            }
            return _countryService.CheckCountryExists((int)countryId).Result;
        }

        private async Task<IResult> CheckIfProductExistWithName(string productName)
        {
            if (await _productDal.Get(p => p.Name == productName) != null)
                return new ErrorResult(Messages.ProductAlreadyExists);

            return new SuccessResult();
        }

        private async Task<IResult> CheckIfBrandExistsById(int brandId)
        {
            if (await _brandService.GetBrandById(brandId) == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            return new SuccessResult();
        }
    }
}
