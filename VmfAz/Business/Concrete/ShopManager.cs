using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ShopValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessMotor;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShopManager : IShopService
    {
        private readonly IShopDal _shopDal;
        private readonly IMapper _mapper;

        public ShopManager(IShopDal shopDal, IMapper mapper)
        {
            _shopDal = shopDal;
            _mapper = mapper;
        }
        [AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ShopPostDtoValidator))]
        public async Task<IResult> Add(ShopPostDto shopDto)
        {
            await _shopDal.Add(_mapper.Map<Shop>(shopDto));
            return new SuccessResult(Messages.ShopAdded);
        }
        [AuthorizeOperation("Admin,SuperAdmin")]
        public async Task<IResult> Delete(int id)
        {
            Shop shop = await _shopDal.Get(x => x.Id == id);
            if (shop == null)
                return new ErrorResult(Messages.ShopNotFound);
            await _shopDal.Delete(shop);
            return new SuccessResult(Messages.ShopDeleted);
        }

        public async Task<IDataResult<List<Shop>>> GetAll()
        {
            return new SuccessDataResult<List<Shop>>(await _shopDal.GetAll(), Messages.ShopListed);
        }

        public async Task<IDataResult<Shop>> GetById(int id)
        {
            Shop shop = await _shopDal.Get(x => x.Id == id);
            if (shop==null)
            {
                return new ErrorDataResult<Shop>(Messages.ShopNotFound);
            }
            return new SuccessDataResult<Shop>(shop);
        }

        public async Task<IDataResult<List<Shop>>> GetShopsByProduct(int productId)
        {
            return new SuccessDataResult<List<Shop>>(await _shopDal.GetShopsByProduct(productId), Messages.ShopListed);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        [ValidationAspect(typeof(ShopPostDtoValidator))]
        public async Task<IResult> Update(int id, ShopPostDto shopDto)
        {
            IResult result = BusinessRules.Run(
                await CheckIfShopExist(id),
                await CheckIfShopExistWithName(shopDto.Name));
            if (result != null)
                return result;

            Shop shop = _mapper.Map<Shop>(shopDto);
            shop.Id = id;
            await _shopDal.Update(shop);
            return new SuccessResult(Messages.ShopUpdated);
        }

        //Businness Rule

        private async Task<IResult> CheckIfShopExistWithName(string shopName)
        {
            var result = await _shopDal.Get(x => x.Name == shopName);
            if (result != null)
                return new ErrorResult(Messages.ShopAlreadyExist);
            return new SuccessResult();
        }
        private async Task<IResult> CheckIfShopExist(int shopId)
        {
            var result = await _shopDal.Get(x => x.Id == shopId);
            if (result != null)
                return new ErrorResult(Messages.ShopAlreadyExist);
            return new SuccessResult();
        }
    }
}
