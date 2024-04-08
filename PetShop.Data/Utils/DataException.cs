using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Utils
{
    public class DataException : Exception
    {
        public DataException(string message=null, Exception inner=null) : base(message,inner) { }
        
    }

    public class EntityNotFoundException : DataException
    {
        public EntityNotFoundException(string message = null, Exception inner = null) : base(message, inner) { }
        
    }

    public class DuplicateEntityException : DataException
    {
        public DuplicateEntityException(string message = null, Exception inner = null) : base(message, inner) { }

    }

    public class InvalidEntityException : DataException
    {
        public InvalidEntityException(string message = null, Exception inner = null) : base(message, inner) { }
        
    }
}
