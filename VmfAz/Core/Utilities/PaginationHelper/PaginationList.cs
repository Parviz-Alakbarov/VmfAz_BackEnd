using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.PaginationHelper
{
    public class PaginationList<T> : List<T>
    {
        public PaginationList(List<T> items, int count, int currentPage, int itemsPerPage)
        {
            CurrentPage = currentPage;
            TotalItems = count;
            PageSize = itemsPerPage;
            TotalPage = (int)Math.Ceiling(count / (double)itemsPerPage);
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }

        public static async Task<PaginationList<T>> CreateAsync(IQueryable<T> query, int currentPage, int itemPerPage)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((currentPage - 1) * itemPerPage).Take(itemPerPage).ToListAsync();
            return new PaginationList<T>(items, count, currentPage, itemPerPage);
        }
    }
}
