using Business.Abstract;
using Core.Aspects.Autofac.Authorization;
using Core.Utilities.BusinessMotor;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Enums;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, ICountryService countryService, ICityService cityService, IMapper mapper)
        {
            _orderDal = orderDal;
            _countryService = countryService;
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<IResult> Add(OrderAddDto orderAddDto)
        {
            IResult result = BusinessRules.Run(
               await _countryService.CheckCountryExists(orderAddDto.CountryId),
               await _cityService.CheckCityExistsOnCountry(orderAddDto.CountryId, orderAddDto.CityId)
                );
            if (result != null)
                return result;
            Order order = _mapper.Map<Order>(orderAddDto);

            order.OrderTrackId = Guid.NewGuid();
            order.CreatedDate = DateTime.Now.AddHours(4);
            order.UpdateDate = DateTime.Now.AddHours(4);
            order.OrderStatus = OrderStatus.Pending;
            await _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        public async Task<IResult> Update(OrderUpdateDto orderUpdateDto)
        {
            Order order = await _orderDal.Get(x => x.Id == orderUpdateDto.OrderId);
            if (order != null)
                return new ErrorResult(Messages.OrderNotFound);

            order.OrderStatus = orderUpdateDto.OrderStatus;
            await _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        public async Task<IDataResult<List<OrderGetDto>>> GetAll()
        {
            return new SuccessDataResult<List<OrderGetDto>>(await _orderDal.GetOrderInGetDto(), Messages.OrdersListed);
        }

        public async Task<IDataResult<OrderGetDto>> GerOrderById(int orderId)
        {
            OrderGetDto orderGetDto = _mapper.Map<OrderGetDto>(await _orderDal.Get(x => x.Id == orderId));
            if (orderGetDto == null)
                return new ErrorDataResult<OrderGetDto>(Messages.OrderNotFound);
            return new SuccessDataResult<OrderGetDto>(orderGetDto,Messages.OrderFound);
        }

        public async Task<IDataResult<OrderGetDto>> GetOrderByTrackId(Guid trackId)
        {
            OrderGetDto orderGetDto = _mapper.Map<OrderGetDto>(await _orderDal.Get(x => x.OrderTrackId == trackId));
            if (orderGetDto == null)
                return new ErrorDataResult<OrderGetDto>(Messages.OrderNotFound);
            return new SuccessDataResult<OrderGetDto>(orderGetDto, Messages.OrderFound);
        }

        [AuthorizeOperation("AppUser")]
        public async Task<IDataResult<List<OrderGetDto>>> GetAllByUser()
        {
            return new SuccessDataResult<List<OrderGetDto>>(await _orderDal.GetOrderInGetDto(), Messages.OrdersListed);
        }

        


    }
}
