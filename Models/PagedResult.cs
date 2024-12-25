using System;
using System.Collections.Generic;

namespace MapProject.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }  // Use generic type T for flexibility
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}