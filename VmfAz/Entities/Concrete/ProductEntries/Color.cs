using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ProductEntries
{
    public class Color 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexValue { get; set; }

        public List<ProductEntry> ProductEntriesForBelt { get; set; }
        public List<ProductEntry> ProductEntriesForDial { get; set; }
        
    }
}
