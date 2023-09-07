using MongoDB.Driver;
using MongoDbExample.Dto;
using MongoDbExample.Models;
using MongoDbExample.Service;
using MongoDbExample.Settings;

namespace MongoDbExample.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task AddNewCategory(CategoryDto categoryDto)
        {
            await _categoryCollection.InsertOneAsync(new Category { Id = categoryDto.Id, Name = categoryDto.Name });
        }

        public async Task AddNewCategorys(IEnumerable<CategoryDto> categories)
        {
            await _categoryCollection.InsertManyAsync(categories.Select(x => new Category { Id = x.Id, Name = x.Name }).ToList());
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var select = Builders<Category>.Projection.Include(x => x.Name).Exclude(x=>x.Id);

            return await _categoryCollection.Find(x => true).Project<CategoryDto>(select).ToListAsync();
        }

        public CategoryDto GetByCategoryId(string categoryId)
        {
            var select = Builders<Category>.Projection.Include(x => x.Name);

            return _categoryCollection.Find<Category>(x => x.Id == categoryId).Project<CategoryDto>(select).FirstOrDefault();
        }
    }
}
