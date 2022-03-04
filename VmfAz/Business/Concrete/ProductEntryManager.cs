using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductEntryManager : IProductEntryService
    {
        private readonly IProductEntryService _productEntryService;

        public ProductEntryManager(IProductEntryService productEntryService)
        {
            _productEntryService = productEntryService;
        }

        public IResult Add(ProductEntry productEntry)
        {
            _productEntryService.Add(productEntry);
            return new SuccessResult(); 
        }

    }
}
