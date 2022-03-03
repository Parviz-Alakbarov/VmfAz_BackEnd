using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ProductEntries
{
    public class ProductBeltType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductEntry> ProductEntries { get; set; }
    }
}
