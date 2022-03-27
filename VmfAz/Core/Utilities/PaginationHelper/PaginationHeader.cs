using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.PaginationHelper
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int totalPage, int totalItems, int itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalPage = totalPage;
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
        }

        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }


    }
}
