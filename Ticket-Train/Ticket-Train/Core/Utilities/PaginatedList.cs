﻿using Microsoft.EntityFrameworkCore;

namespace Ticket_Train.Core.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> item , int count , int pageIndex , int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(item);
        }

        public bool HasPreviousPage()
        {
            return PageIndex > 1;
        }
        public bool HasNextPage()
        {
            return PageIndex < TotalPages;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query , int pageIndex , int pageSize)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
