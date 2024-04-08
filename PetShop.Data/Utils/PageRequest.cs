using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Utils
{
    public class PageRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Skip { get { return (PageNumber - 1) * PageSize; } }
        public override string ToString()
        {
            return $"page:{PageNumber};size:{PageSize}";
        }
    }
}
