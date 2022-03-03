﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
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
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(ProductAddDto), Priority =1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(ProductAddDto productAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductLimitExceeded());

            if (result != null)
                return result;

            Product product = _mapper.Map<Product>(productAddDto);

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(ProductUpdateDto productUpdateDto)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListedSuccessfully);
        }

        public IDataResult<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetils(int id)
        {
            throw new NotImplementedException();
        }



        private IResult CheckIfProductLimitExceeded()
        {
            if (_productDal.GetAll().Count>=10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
