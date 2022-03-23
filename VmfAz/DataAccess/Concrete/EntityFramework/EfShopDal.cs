using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShopDal : EfEntityRepositoryBase<Shop, VmfAzContext>, IShopDal
    {
        public List<Shop> GetShopsByProduct(int productId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from shop in context.Shops
                             join productShop in context.ProductShops
                                on shop.Id equals productShop.ShopId
                             where productShop.ProductId == productId
                             select shop;
                return result.ToList();
            }
        }
    }
}
