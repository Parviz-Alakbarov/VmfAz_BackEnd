using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ProductEntries
{
    public class ProductWaterResistance
    {
        public int Id { get; set; }
        public string ResistanceValue { get; set; }
        public List<Product> Products { get; set; }

    }
}
