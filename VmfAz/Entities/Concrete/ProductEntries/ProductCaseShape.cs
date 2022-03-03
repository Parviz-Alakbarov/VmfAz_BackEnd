using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ProductEntries
{
    public class ProductCaseShape
    {
        public int Id { get; set; }
        public string Shape { get; set; }
        public List<Product> Products { get; set; }

    }
}
