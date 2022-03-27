using Core.Utilities.PaginationHelper;
using Core.Utilities.Results.Abstract;
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
        Task<IDataResult<Product>> GetProductById(int id);
        Task<IDataResult<List<Product>>> GetAll();
        Task<IDataResult<ProductDetailDto>> GetProductDetils(int id);
        Task<IDataResult<List<ProductGetDto>>> GetProductsInGetDto();
        Task<IDataResult<List<ProductGetDto>>> GetProductsByBrandId(int brandId);
        Task<IDataResult<List<ProductGetDto>>> GetBestSellerProducts(int count);
        Task<IDataResult<List<ProductGetDto>>> GetBestSellerProductsByBrandId(int brandId,int count);
        Task<IDataResult<List<ProductGetDto>>> GetDiscountedProducts(int? count);
        Task<IDataResult<List<ProductGetDto>>> SearchProducts(string name);

        Task<IDataResult<List<ProductGetDto>>> GetRelatedProducts(int productId);

        Task<IDataResult<PaginationList<ProductGetDto>>> GetProductsPagination(UserParams userParams);

        Task<IResult> Add(ProductAddDto productAddDto);
        Task<IResult> Update(int id,ProductUpdateDto productUpdateDto);
        Task<IResult> Delete(int id);
        Task<IResult> UnDelete(int id);
    }
}
