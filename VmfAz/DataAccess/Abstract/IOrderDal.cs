using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public  interface IOrderDal : IEntityRepository<Order>
    {
        Task<List<OrderGetDto>> GetOrderInGetDto(Expression<Func<OrderGetDto, bool>> expression = null);
    }
}
