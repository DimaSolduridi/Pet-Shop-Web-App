using PetShop.Data.Utils;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        //Task<PageResponse<T>> Get(PageRequest request);
    }
}
