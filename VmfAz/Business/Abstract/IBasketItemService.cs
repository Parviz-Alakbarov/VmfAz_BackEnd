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
        IDataResult<List<BasketItem>> Add(BasketItemAddDto basketItemAddDto);
        IResult IncreaseCount(int basketItemId);
        IResult DecreaseCount(int basketItemId);
        IResult Delete(int basketItemId);
        IDataResult<List<BasketItem>> GetAllBasketItemsByUserId(int userId);
    }
}
