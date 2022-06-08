using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Shared.Infra
{
    public class BaseRepository<T> where T : Entity
    {
        public readonly AppDbContext _context;
        public readonly DbSet<T> _data;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _data = context.Set<T>();
        }

        public async virtual Task InsertAsync(T registro)
        {
            await _data.AddAsync(registro);

            await _context.SaveChangesAsync();
        }

        public async virtual Task Update(T registro)
        {
            _data.Update(registro);

            await _context.SaveChangesAsync();
        }

        public async virtual Task Delete(T registro)
        {
            _data.Remove(registro);

            await _context.SaveChangesAsync();
        }

        public async virtual Task<bool> ExistsByIdAsync(Guid id)
        {
            return await _data.AnyAsync(x => x.Id == id);
        }

        public async virtual Task<IList<T>> GetAllAsync()
        {
            return await _data.ToListAsync();
        }

        public async virtual Task<T?> GetByIdAsync(Guid id)
        {
            return await _data.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
