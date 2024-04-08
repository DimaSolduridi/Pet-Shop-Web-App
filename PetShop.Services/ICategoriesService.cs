using PetShop.Models.Dtos;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface ICategoriesService
    {
        public Task<CategoryDto> GetCategoryById(int id);
        public Task<IEnumerable<CategoryDto>> GetAllCategories();
    }
}
