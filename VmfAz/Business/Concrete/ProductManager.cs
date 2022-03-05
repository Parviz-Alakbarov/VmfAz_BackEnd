using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ProductValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessMotor;
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
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper, ICountryService countryService)
        {
            _productDal = productDal;
            _mapper = mapper;
            _countryService = countryService;
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

            Product product = _mapper.Map<Product>(productAddDto);
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        [AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ProductUpdateDtoValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            Product product = _productDal.Get(x => !x.IsDeleted && x.Id == id);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.CostPrice = productUpdateDto.CostPrice;
            product.SalePrice = productUpdateDto.SalePrice;
            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.Image = productUpdateDto.Image;
            product.DiscountPercent = productUpdateDto.DiscountPercent;

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdatedSuccesfully);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int productId)
        {
            Product product = _productDal.Get(x => !x.IsDeleted && x.Id == productId);
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
            Product product = _productDal.Get(x => x.Id == productId);
            if (product == null)
            {
                return new ErrorResult(Messages.ProductNotFound);
            }
            product.IsDeleted = false;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductDeletedSuccessfully);
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListedSuccessfully);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            var result = _productDal.Get(p => p.Id == productId);
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
    }
}
