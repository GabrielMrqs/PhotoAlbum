using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

namespace Albums.Infra.ClientModule
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(AppDbContext contexto) : base(contexto)
        {
        }
        public async Task<Client?> GetByEmailAsync(string email)
        {
            return await _data.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
