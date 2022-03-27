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
        Task<IResult> Add(int productId, IFormFile file);
        Task<IResult> Delete(ProductImage productImage);
        Task<IResult> Update(ProductImage productImage, IFormFile file);
        Task<IDataResult<List<ProductImage>>> GetAll();
        Task<IDataResult<ProductImage>> GetById(int imageId);
        Task<IDataResult<List<ProductImage>>> GetProductImages(int productId);
    }
}
