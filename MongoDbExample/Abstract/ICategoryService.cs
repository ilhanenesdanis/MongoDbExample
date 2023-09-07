using MongoDbExample.Dto;

namespace MongoDbExample.Service
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        public CategoryDto GetByCategoryId(string categoryId);
        public Task AddNewCategory(CategoryDto categoryDto);
        public Task AddNewCategorys(IEnumerable<CategoryDto> categories);

    }
}
