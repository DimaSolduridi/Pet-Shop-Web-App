using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class CategoryRepository: IRepository<Category>
    {
        private readonly PetShopDbContext _context;

        public CategoryRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Category category)
        {
            await _context.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
                


        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //TODO: to use in validation when adding new category
        private async Task<Animal> GetByName(Category category)
        {
            return await _context.Animals.FindAsync(category.Name);
        }
    }
}
