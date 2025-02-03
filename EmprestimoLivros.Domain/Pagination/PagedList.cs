using System;
using System.Collections.Generic;

namespace EmprestimoLivros.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(IEnumerable<T> items, int pageNumber, int pageSize, int count)
        {
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;

            AddRange(items);
        }

        public PagedList(IEnumerable<T> items, int currentPage, int totalPage, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPage = totalPage;
            PageSize = pageSize;
            TotalCount = totalCount;

            AddRange(items);
        }
    }
}
