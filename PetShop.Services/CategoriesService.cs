using AutoMapper;
using PetShop.Data.Repositories;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class CategoriesService: ICategoriesService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesService(IRepository<Category> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _repository.GetAll();
            var categoriesDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDtos;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var categoryDto = _mapper.Map<CategoryDto>(await _repository.GetById(id));
            return categoryDto;
        }

    }
}
