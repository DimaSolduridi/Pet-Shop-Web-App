using AutoMapper;
using PetShop.Data.Repositories;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;



namespace PetShop.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public AnimalsService(IRepository<Animal> animalRepository,
            IRepository<Category> categoryRepository
            ,IMapper mapper)
        {
            _animalRepository = animalRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        
        public async Task<int> AddAnimal(AnimalDto animalDto)
        {
            
            var animal = _mapper.Map<Animal>(animalDto);
           
            return await _animalRepository.Add(animal);
        }

        public async Task DeleteAnimal(int id)
        {
            var animal = await _animalRepository.GetById(id);
            

            await _animalRepository.Delete(id);
        }

        public async Task UpdateAnimal(AnimalDto animalDto)
        {
            var existingAnimal=  await _animalRepository.GetById(animalDto.AnimalId);
            
            if (existingAnimal != null)
            {
                existingAnimal.Name = animalDto.Name;
                existingAnimal.Age = animalDto.Age;
                existingAnimal.Description = animalDto.Description;
                existingAnimal.CategoryId = animalDto.CategoryId;
                existingAnimal.PhotoUri = animalDto.PhotoUri;
            }
            
            await _animalRepository.Update(existingAnimal!);
        }

        public async Task<IEnumerable<AnimalDto>> GetAllAnimals()
        {
            var animals = await _animalRepository.GetAll();
            var AnimalDtos = _mapper.Map<IEnumerable<AnimalDto>>(animals);
            return AnimalDtos;
            
        }

        public async Task<AnimalDto> GetAnimalById(int id)
        {
            var animal = _mapper.Map<AnimalDto>(await _animalRepository.GetById(id));
            return animal;
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimalsByCategory(IEnumerable<AnimalDto> animals, int categoryId)
        {
            var selectedCategory = await _categoryRepository.GetById(categoryId);
            var animalsByCategory = animals.Where(a => a.CategoryId == selectedCategory.CategoryId).ToList();
            return animalsByCategory;
        }

        public IEnumerable<AnimalDto> GetTopCommentedAnimals(IEnumerable<AnimalDto> animals)
        {
            var top2Animals = animals.OrderByDescending(animal => animal.Comments.Count()).Take(2);
            return top2Animals;
        }







        //public async Task<PageResponse<Animal>> GetAnimals(PageRequest request)
        //{
        //    return await _repository.Get(request);
        //}
    }
}
