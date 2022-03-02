﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService 
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDto>> GetProductDetils(int id);
        IDataResult<Product> GetProductById(int id);

        IResult Add(ProductAddDto productPostDto);
        IResult Update(ProductUpdateDto productUpdateDto);
        IResult Delete(Product product);
    }
}
