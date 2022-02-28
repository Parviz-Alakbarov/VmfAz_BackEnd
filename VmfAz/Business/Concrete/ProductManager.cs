using AutoMapper;
using Business.Abstract;
using Business.Constants;
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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public IResult Add(ProductAddDto productPostDto)
        {

            Product product = _mapper.Map<Product>(productPostDto);

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetils()
        {
            throw new NotImplementedException();
        }

        public IResult Update(ProductUpdateDto productUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
