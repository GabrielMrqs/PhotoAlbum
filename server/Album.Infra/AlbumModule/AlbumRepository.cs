using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

namespace Albums.Infra.AlbumModule
{
    public class AlbumRepository : BaseRepository<Album>
    {
        public AlbumRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Album?> GetByClientIdAsync(Guid clientId)
        {
            return await _data.Include(x => x.Photos).FirstOrDefaultAsync(x => x.ClientId == clientId);
        }
    }
}
