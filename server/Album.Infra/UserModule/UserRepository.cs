using Albums.Domain;
using MongoDB.Driver;
using Shared.Infra;

namespace Albums.Infra.UserModule
{
    public class UserRepository : MongoRepository<User>
    {
        public UserRepository(IMongoClient client) : base(client)
        {
        }

        protected override string CollectionName => "Users";
    }
}
