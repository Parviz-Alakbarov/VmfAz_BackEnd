using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShopService
    {
        IDataResult<List<Shop>> GetAll();
        IDataResult<List<Shop>> GetShopsByProduct(int productId);

        IResult Add(Shop shop);
        IResult Update(Shop shop);
        IResult Delete(int id);


    }
}
