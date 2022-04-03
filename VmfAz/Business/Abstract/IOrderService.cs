using Core.Utilities.Results.Abstract;
using Entities.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<IResult> Add(OrderAddDto orderAddDto);
        Task<IResult> Update(OrderUpdateDto orderUpdateDto);
        Task<IDataResult<List<OrderGetDto>>> GetAll();
        Task<IDataResult<OrderGetDto>> GerOrderById(int orderId);
    }
}
