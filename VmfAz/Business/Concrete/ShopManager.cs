using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Authorization;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public ShopManager(IShopDal shopDal)
        {
            _shopDal = shopDal;
        }
        [AuthorizeOperation("Admin,SuperAdmin")]
        public IResult Add(Shop shop)
        {
            _shopDal.Add(shop);
            return new SuccessResult(Messages.ShopAdded);
        }
        [AuthorizeOperation("Admin,SuperAdmin")]

        public async Task<IResult> Delete(int id)
        {
            Shop shop = await _shopDal.Get(x => x.Id == id);
            if (shop == null)
                return new ErrorResult(Messages.ShopNotFound);
            _shopDal.Delete(shop);
            return new SuccessResult(Messages.ShopDeleted);
        }

        public async Task<IDataResult<List<Shop>>> GetAll()
        {
            return new SuccessDataResult<List<Shop>>(await _shopDal.GetAll(),Messages.ShopListed);
        }

        public async Task<IDataResult<List<Shop>>> GetShopsByProduct(int productId)
        {
            return new SuccessDataResult<List<Shop>>( await _shopDal.GetShopsByProduct(productId),Messages.ShopListed);
        }

        [AuthorizeOperation("Admin,SuperAdmin")]
        public IResult Update(Shop shop)
        {
            _shopDal.Update(shop);
            return new SuccessResult(Messages.ShopUpdated);
        }
    }
}
