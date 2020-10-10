using System.Collections;
using System.Collections.Generic;

namespace _6MKT.BackOffice.Domain.ValueObjects.Pagination
{
    public class PageResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
    }
}