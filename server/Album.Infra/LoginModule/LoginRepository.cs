using Albums.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Shared.Infra;

namespace Albums.Infra.LoginModule
{
    public class LoginRepository : MongoRepository<Login>
    {
        public LoginRepository(IMongoClient client) : base(client)
        {
        }

        protected override string CollectionName => "Login";

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await Collection.Find(x => x.Email == email).AnyAsync();
        }

        public async Task<Guid?> LoginAsync(string email, string password)
        {
            var login = await Collection.Find(x => x.Password == password &&
                                                   x.Email == email).
                                                   FirstOrDefaultAsync();
            return login?.UserId;
        }
    }
}
