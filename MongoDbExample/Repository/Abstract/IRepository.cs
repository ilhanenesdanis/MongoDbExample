using MongoDbExample.Models;

namespace MongoDbExample.Repository.Abstract
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(string id);
        Task<T> GetByIdAsync(string id);
        Task DeleteAsync(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
