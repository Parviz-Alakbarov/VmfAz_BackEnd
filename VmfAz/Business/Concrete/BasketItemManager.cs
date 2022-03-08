﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Authorization;
using Core.Utilities.BusinessMotor;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.OrderDTOs;
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

        public BasketItemManager(IBasketItemDal basketItemDal, IMapper mapper, IUserService userService, IProductService productService)
        {
            _basketItemDal = basketItemDal;
            _mapper = mapper;
            _userService = userService;
            _productService = productService;
        }

        public IDataResult<List<BasketItem>> Add(BasketItemAddDto basketItemAddDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfAppUserExists(basketItemAddDto.AppUserId),
                CheckIfProductExists(basketItemAddDto.ProductId));
            if (result != null)
                return new ErrorDataResult<List<BasketItem>>(result.Message);

            BasketItem item = _basketItemDal.Get(x => x.ProductId == basketItemAddDto.ProductId && x.AppUserId == basketItemAddDto.AppUserId);
            if (item == null)
            {
                item = _mapper.Map<BasketItem>(basketItemAddDto);
                _basketItemDal.Add(item);
            }
            else
            {
                item.Count += basketItemAddDto.Count;
                _basketItemDal.Update(item);
            }
            List<BasketItem> basketItems = _basketItemDal.GetAll(x => x.AppUserId == basketItemAddDto.AppUserId);
            return new SuccessDataResult<List<BasketItem>>(basketItems, Messages.ProductAddedToBasket);
        }

        public IResult DecreaseCount(int basketItemId)
        {
            var item = _basketItemDal.Get(x => x.Id == basketItemId);
            if (item == null)
            {
                return new ErrorResult(Messages.BasketItemNotFound);
            }
            if (item.Count == 1)
            {
                _basketItemDal.Delete(item);
            }
            item.Count--;
            _basketItemDal.Update(item);
            return new SuccessResult();
        }

        public IResult Delete(int basketItemId)
        {
            var item = _basketItemDal.Get(x => x.Id == basketItemId);
            if (item == null)
            {
                return new ErrorResult(Messages.BasketItemNotFound);
            }
            _basketItemDal.Delete(item);
            return new SuccessResult(Messages.BasketItemDeletedSuccessfully);
        }

        public IDataResult<List<BasketItem>> GetAllBasketItemsByUserId(int userId)
        {
            return new SuccessDataResult<List<BasketItem>>(_basketItemDal.GetAll(x => x.AppUserId == userId));
        }

        public IResult IncreaseCount(int basketItemId)
        {
            var item = _basketItemDal.Get(x => x.Id == basketItemId);
            if (item == null)
            {
                return new ErrorResult(Messages.BasketItemNotFound);
            }
            if (item.Count == 10)
            {
                return new ErrorResult(Messages.BasketItemLimitExceeded);
            }
            item.Count++;
            _basketItemDal.Update(item);
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