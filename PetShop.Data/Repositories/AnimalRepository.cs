using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Utils;
using PetShop.Models.Entities;

namespace PetShop.Data.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> Add(Animal entity)
        {
            var duplicateAnimal = await _context.Animals.SingleOrDefaultAsync(a => a.Name == entity.Name);
            if (duplicateAnimal == null)
            {
                await _context.AddAsync(entity);
                return await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateEntityException("An entity with this name is already in the data base");
            }
            
        }

        public async Task Delete(int id)
        {
            var animal= await _context.Animals.SingleOrDefaultAsync(a=>a.AnimalId==id);
            if (animal!=null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidEntityException("No entity with this id");
            }
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.AnimalId == id);
            if (animal != null)
            {
                return animal;
            }
            else
            {
                throw new EntityNotFoundException("Entity with this id was not found in data base");
            }
            
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            return await _context.Animals.ToListAsync();

        }
        
        public async Task Update(Animal entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

       

        //public async Task<PageResponse<Animal>> Get(PageRequest request)
        //{
        //    //TODO: add validation for logical page number and etc
        //    var data = _context.Animals;
        //    return new PageResponse<Animal>()
        //    {
        //        PageNumber = request.PageNumber,
        //        PageSize = request.PageSize,
        //        TotalCount = await data.CountAsync(),
        //        Data = await data.Skip(request.Skip).Take(request.PageSize).ToArrayAsync(),
        //    };
        //}


    }
}
