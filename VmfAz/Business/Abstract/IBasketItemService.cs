using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketItemService
    {
        Task<IDataResult<List<BasketItem>>> Add(BasketItemAddDto basketItemAddDto);
        Task<IResult> Update(BasketItemUpdateDto basketItemUpdateDto);
        Task<IResult> Delete(int basketItemId);
        Task<IDataResult<List<BasketItem>>> GetAllBasketItemsByUserId();
    }
}
