using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

namespace Albums.Infra.LoginModule
{
    public class LoginRepository : BaseRepository<Login>
    {
        public LoginRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _data.AnyAsync(x => x.Email == email);
        }

        public async Task<Guid?> LoginAsync(string email, string password)
        {
            var login = await _data.FirstOrDefaultAsync(x => x.Password == password && x.Email == email);
            return login?.ClientId;
        }
    }
}
