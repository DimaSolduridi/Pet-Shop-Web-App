using AutoMapper;
using Microsoft.Identity.Client;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.MapperProfiles
{
    public class AnimalMapperProfile : Profile
    {
        public AnimalMapperProfile()
        {
            CreateMap<Animal,AnimalDto>().ReverseMap();

            

        }
        
    }
}
