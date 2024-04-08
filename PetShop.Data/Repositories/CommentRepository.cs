using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Utils;
using PetShop.Models.Entities;

namespace PetShop.Data.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly PetShopDbContext _context;

        public CommentRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Comment entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(c => c.CommentId == id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidEntityException("No entity with this id");
            }
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Comments.Include(c => c.Animal).ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
            if (comment != null)
            {
                return comment;
            }
            else
            {
                throw new EntityNotFoundException("Entity with this id was not found in data base");
            }
        }

        public async Task Update(Comment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
