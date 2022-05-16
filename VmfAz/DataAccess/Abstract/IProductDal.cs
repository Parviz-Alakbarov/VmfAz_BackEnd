using Core.DataAccess;
using Core.Utilities.PaginationHelper;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<ProductDetailDto> GetProductDetails(int id);
        Task<List<ProductGetDto>> GetProductsInGetDto(int? count=null,Expression<Func<ProductGetDto, bool>> expression = null);
        Task<List<ProductGetDto>> GetBestSellerProducts(int count , Expression<Func<ProductGetDto, bool>> expression = null);
        Task<PaginationList<ProductGetDto>> GetProductsPaginated(UserParams userParams, int pageSize);
        Task<PaginationList<ProductGetDtoAdmin>> GetProductsPaginatedAdmin(AdminParams adminParams);
    }
}
