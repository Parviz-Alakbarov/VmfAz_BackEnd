using AutoMapper;
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
        [AuthorizeOperation("SuperAdmin")]
        [ValidationAspect(typeof(ProductAddDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(ProductAddDto productAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckCountryExist(productAddDto.CountryId),
                CheckIfProductExistWithName(productAddDto.Name));

            if (result != null)
                return result;

            var posterImageResult = FileHelper.Upload("Products",productAddDto.PosterImage);
            if (!posterImageResult.Success)
                return new ErrorResult(posterImageResult.Message);

            Product product = _mapper.Map<Product>(productAddDto);
            product.PosterImage = posterImageResult.Message;
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ProductUpdateDtoValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductExistWithName(productUpdateDto.Name));
            if (result != null)
                return result;

            Product product = _productDal.Get(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }

            if (productUpdateDto.PosterImage!=null)
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

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdatedSuccesfully);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int productId)
        {
            Product product = _productDal.Get(x => x.Id == productId && !x.IsDeleted);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.IsDeleted = true;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductDeletedSuccessfully);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult UnDelete(int productId)
        {
            Product product = _productDal.Get(x => x.Id == productId && x.IsDeleted);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.IsDeleted = false;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUndeletedSuccessfully);
        }

        [CacheAspect(15)]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x=>!x.IsDeleted), Messages.ProductsListedSuccessfully);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            var result = _productDal.Get(p => p.Id == productId && !p.IsDeleted);
            if (result == null)
            {
                return new ErrorDataResult<Product>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<Product>(result);
        }
        public IDataResult<ProductDetailDto> GetProductDetils(int id)
        {
            var result = _productDal.GetProductDetails(id);
            if (result == null)
            {
                return new ErrorDataResult<ProductDetailDto>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<ProductDetailDto>(result);
        }

        public IDataResult<List<ProductGetDto>> GetProductsByBrandId(int brandId)
        {
            IResult businessResult = BusinessRules.Run(CheckIfBrandExistsById(brandId));
            if (businessResult != null)
                return new ErrorDataResult<List<ProductGetDto>>(businessResult.Message);

            var result = _productDal.GetProductsInGetDto(x=>x.BrandId == brandId);
            if (result == null)
            {
                return new ErrorDataResult<List<ProductGetDto>>(Messages.ProductNotFound);
            }

            return new SuccessDataResult<List<ProductGetDto>>(result);
        }

        [CacheAspect]
        public IDataResult<List<ProductGetDto>> GetProcutsInGetDto()
        {
            return new SuccessDataResult<List<ProductGetDto>>(_productDal.GetProductsInGetDto(), Messages.ProductsListedSuccessfully);
        }


        //Business Rules
        private IResult CheckCountryExist(int? countryId)
        {
            if (countryId == null)
            {
                return new SuccessResult();
            }
            return _countryService.CheckCountryExists((int)countryId);
        }

        private IResult CheckIfProductExistWithName(string productName)
        {
            if (_productDal.Get(p => p.Name == productName) != null)
                return new ErrorResult(Messages.ProductAlreadyExists);

            return new SuccessResult();
        }

        private IResult CheckIfBrandExistsById(int brandId)
        {
            if (_brandService.GetBrandById(brandId)==null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            return new SuccessResult();
        }

        
    }
}
