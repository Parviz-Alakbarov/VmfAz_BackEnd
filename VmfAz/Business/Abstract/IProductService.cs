using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<List<ProductDetailDto>> GetProductDetils();
        IDataResult<Product> GetProductById(int id);

        IResult Add(ProductAddDto productPostDto);
        IResult Update(ProductUpdateDto productUpdateDto);
        IResult Delete(Product product);
    }
}
