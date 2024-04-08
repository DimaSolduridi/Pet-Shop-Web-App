using PetShop.Data.Utils;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;

namespace PetShop.Services
{
    public interface IAnimalsService
    {
        //Task<PageResponse<Animal>> GetAnimals(PageRequest request);

        Task<int> AddAnimal(AnimalDto animal);
        Task DeleteAnimal(int id);
        Task<AnimalDto> GetAnimalById(int id);
        Task<IEnumerable<AnimalDto>> GetAllAnimals();
        Task <IEnumerable<AnimalDto>> GetAnimalsByCategory(IEnumerable<AnimalDto> animals,int id);
        IEnumerable<AnimalDto> GetTopCommentedAnimals(IEnumerable<AnimalDto> animals);
        Task UpdateAnimal(AnimalDto animal);
        
    }
}