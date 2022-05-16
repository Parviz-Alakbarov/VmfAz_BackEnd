using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.PaginationHelper
{
    public class AdminParams
    {
        public int PageNumber { get; set; } = 1;

        private const int MaxPageSize = 50;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public string OrderBy { get; set; } = "created";

    }
}
