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
    public interface IShopService
    {
        Task<IDataResult<List<Shop>>> GetAll();
        Task<IDataResult<List<Shop>>> GetShopsByProduct(int productId);

        Task<IResult> Add(ShopPostDto shopDto);
        Task<IResult> Update(int id,ShopPostDto shopDto);
        Task<IResult> Delete(int id);


    }
}
