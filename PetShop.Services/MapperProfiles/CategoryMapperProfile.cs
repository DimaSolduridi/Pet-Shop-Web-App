using AutoMapper;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;

namespace PetShop.Services.MapperProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
        
    }
}
