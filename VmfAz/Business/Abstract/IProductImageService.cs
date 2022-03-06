using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(int productId, IFormFile file);
        IResult Delete(ProductImage productImage);
        IResult Update(ProductImage productImage, IFormFile file);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int imageId);
        IDataResult<List<ProductImage>> GetProductImages(int productId);
    }
}
