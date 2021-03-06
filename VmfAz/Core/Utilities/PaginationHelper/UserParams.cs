using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.PaginationHelper
{
    public class UserParams
    {
        public int PageNumber { get; set; } = 1;

        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public int[] BrandIds { get; set; }
        public int[] GenderIds { get; set; }
        public int[] ProductFunctionalityIds { get; set; }
        public string OrderBy { get; set; } = "created";

    }
}
