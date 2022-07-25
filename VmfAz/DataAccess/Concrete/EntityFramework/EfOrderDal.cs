using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, VmfAzContext>, IOrderDal
    {
        public async Task<List<OrderGetDto>> GetOrderInGetDto(Expression<Func<OrderGetDto, bool>> expression = null)
        {
            using (VmfAzContext context = new())
            {
                var result = from order in context.Orders
                             select new OrderGetDto
                             {
                                 Address = order.Address,
                                 CityId = order.CityId,
                                 CountryId = order.CountryId,
                                 Email = order.Email,
                                 FirstName = order.FirstName,
                                 LastName = order.LastName,
                                 Id = order.Id,
                                 Note = order.Note,
                                 PhoneNumber = order.PhoneNumber,
                                 ShippingTypeId = order.ShippingTypeId,
                                 TotalPrice = order.TotalPrice,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
