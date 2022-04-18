using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.BasketItemValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Utilities.BusinessMotor;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BasketItemManager : IBasketItemService
    {
        private readonly IBasketItemDal _basketItemDal;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketItemManager(IBasketItemDal basketItemDal, IMapper mapper,
            IUserService userService, IProductService productService, IHttpContextAccessor contextAccessor)
        {
            _basketItemDal = basketItemDal;
            _mapper = mapper;
            _userService = userService;
            _productService = productService;
            _httpContextAccessor = contextAccessor;
        }

        [ValidationAspect(typeof(BasketItemAddDtoValidator), Priority = 1)]
        public async Task<IDataResult<List<BasketItem>>> Add(BasketItemAddDto basketItemAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfAppUserExists(basketItemAddDto.AppUserId),
                CheckIfProductExists(basketItemAddDto.ProductId));
            if (result != null)
                return new ErrorDataResult<List<BasketItem>>(result.Message);

            BasketItem item = await _basketItemDal.Get(x => x.ProductId == basketItemAddDto.ProductId && x.AppUserId == basketItemAddDto.AppUserId);
            if (item == null)
            {
                item = _mapper.Map<BasketItem>(basketItemAddDto);
                await _basketItemDal.Add(item);
            }
            else
            {
                item.Count += basketItemAddDto.Count;
                await _basketItemDal.Update(item);
            }
            List<BasketItem> basketItems = await _basketItemDal.GetAll(x => x.AppUserId == basketItemAddDto.AppUserId);
            return new SuccessDataResult<List<BasketItem>>(basketItems, Messages.ProductAddedToBasket);
        }

        [AuthorizeOperation("AppUser")]
        public async Task<IResult> Delete(int basketItemId)
        {
            var item = await _basketItemDal.Get(x => x.Id == basketItemId);
            if (item == null)
            {
                return new ErrorResult(Messages.BasketItemNotFound);
            }
            await _basketItemDal.Delete(item);
            return new SuccessResult(Messages.BasketItemDeletedSuccessfully);
        }

        [AuthorizeOperation("AppUser,Admin,SuperAdmin")]
        public async Task<IDataResult<List<BasketItem>>> GetAllBasketItemsByUserId()
        {
            var idResult = _httpContextAccessor.HttpContext.User.GetNameIdentifier()[0];
            if (!Int32.TryParse(idResult, out int userId))
                return new ErrorDataResult<List<BasketItem>> (Messages.UserNotFound);

            IResult result = BusinessRules.Run(CheckIfAppUserExists(userId));
            if (result != null)
                return new ErrorDataResult<List<BasketItem>>(Messages.UserNotFound);

            return new SuccessDataResult<List<BasketItem>>(await _basketItemDal.GetAll(x => x.AppUserId == userId));
        }
        [AuthorizeOperation("AppUser")]
        public async Task<IResult> Update(BasketItemUpdateDto basketItemUpdateDto)
        {
            var item = await _basketItemDal.Get(x => x.Id == basketItemUpdateDto.Id);
            if (item == null)
            {
                return new ErrorResult(Messages.BasketItemNotFound);
            }
            if (item.Count > 10 || item.Count < 1)
            {
                return new ErrorResult(Messages.BasketItemLimitExceeded);
            }
            item.Count = basketItemUpdateDto.Count;
            await _basketItemDal.Update(item);
            return new SuccessResult();
        }

        //Business Rules 

        private IResult CheckIfAppUserExists(int appUserId)
        {
            if (_userService.GetById(appUserId) == null)
                return new ErrorResult(Messages.UserNotFound);

            return new SuccessResult();
        }

        private IResult CheckIfProductExists(int productId)
        {
            if (_productService.GetProductById(productId) == null)
                return new ErrorResult(Messages.ProductNotFound);

            return new SuccessResult();
        }
    }
}
