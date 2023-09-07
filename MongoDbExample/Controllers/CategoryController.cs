using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Dto;
using MongoDbExample.Models;
using MongoDbExample.Repository.Abstract;

namespace MongoDbExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _repository.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoy(CategoryDto category)
        {
            await _repository.AddAsync(new Category()
            {
                Name = category.Name,
            });
            return Ok("işlem başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _repository.DeleteAsync(new Category()
            {
                Id = id
            });
            return Ok("İşlem Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            await _repository.UpdateAsync(new Category()
            {
                Id=category.Id,
                Name=category.Name
            });
            return Ok("İşlem Başarılı");
        }
        [HttpGet]
        public async Task<IActionResult> GetByCategory(string id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }
    }
}
