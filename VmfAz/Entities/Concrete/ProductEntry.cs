using Core.Entities;
using Entities.Concrete.ProductEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductEntry : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductBeltTypeId { get; set; }
        public int ProductCaseSizeId { get; set; }
        public int ProductBeltColorId { get; set; }
        public int ProductDialColorId { get; set; }


        public Product Product { get; set; }
        public ProductBeltType ProductBeltType { get; set; }
        public ProductCaseSize ProductCaseSize { get; set; }
        public Color ProductDialColor { get; set; }

        public Color ProductBeltColor { get; set; }
    }
}
