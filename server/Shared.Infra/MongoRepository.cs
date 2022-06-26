using MongoDB.Driver;
using Shared.Domain;

namespace Shared.Infra
{
    public abstract class MongoRepository<T> where T : Entity
    {
        private const string DatabaseName = "AlbumDB";
        public MongoRepository(IMongoClient client)
        {
            var database = client.GetDatabase(DatabaseName);
            Collection = database.GetCollection<T>(CollectionName);
        }
        protected IMongoCollection<T> Collection { get; }
        protected abstract string CollectionName { get; }
        public async Task Add(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }
        public async Task<T?> GetById(Guid id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;
            return await Collection.Find(filter).ToListAsync();
        }
        public async Task Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }
    }
}
