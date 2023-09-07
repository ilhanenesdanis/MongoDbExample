using MongoDB.Driver;
using MongoDbExample.Models;
using MongoDbExample.Repository.Abstract;
using MongoDbExample.Settings;

namespace MongoDbExample.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly IMongoCollection<T> _collection;
        public Repository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _collection = db.GetCollection<T>(typeof(T).Name);
        }
        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public List<T> GetAll()
        {
            return _collection.AsQueryable().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public T GetById(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }
}
