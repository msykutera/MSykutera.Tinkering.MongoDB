using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MSykutera.Tinkering.MongoDB.Model;

namespace MSykutera.Tinkering.MongoDB.Repostories
{
    public class MongoRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            var currentType = new T();
            _collection = database.GetCollection<T>(currentType.GetType().Name);
        }

        public async Task<IEnumerable<T>> GetAsync(CancellationToken token)
        {
            return await _collection.Find(new BsonDocument()).ToListAsync(token);
        }

        public async Task<string> AddAsync(T model, CancellationToken token)
        {
            await _collection.InsertOneAsync(model, token);
            return model.Id;
        }
    }
}
