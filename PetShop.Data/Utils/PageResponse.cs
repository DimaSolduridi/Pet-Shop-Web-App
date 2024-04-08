using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Utils
{
    public class PageResponse<T> where T : class
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; } = null!;
        public int From { get { return Math.Min((PageNumber - 1) * PageSize + 1, TotalCount); } }
        public int To { get { return Math.Min(PageNumber * PageSize, TotalCount); } }
        public int TotalPages { get { return (int)Math.Ceiling((float)TotalCount / PageSize); } }
        public virtual PageRequest Request { get { return new PageRequest { PageNumber = PageNumber, PageSize = PageSize }; } }
    }
}
