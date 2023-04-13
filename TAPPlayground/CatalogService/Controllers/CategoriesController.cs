using CatalogService.Models;
using CatalogService.Services.Interfaces;
using CatalogService.Models;
using Microsoft.AspNetCore.Mvc;
namespace CatalogService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService _categorysrv;
        public CategoriesController(ICategoryService categorysrv,ILogger<CategoriesController> logger)
        {
            _logger=logger;
            _categorysrv = categorysrv;
        }
        [HttpGet]
        [Route("getallcategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            IEnumerable<Category> categories =await _categorysrv.GetAll();
            _logger.LogInformation("Get all categories method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return categories;
        }
        [HttpGet]
        [Route("getdetails/{id}")]
        public async Task<Category> GetDetails(int id)
        {
            Category category =await _categorysrv.GetDetails(id);
            _logger.LogInformation("Get details of category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return category;
        }
        [HttpPost]
        [Route("insert")]
        public async Task<bool> Insert([FromBody] Category category)
        {
            bool status =await _categorysrv.Insert(category);
            _logger.LogInformation("Insert category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<bool> Update(int id, [FromBody] Category category)
        {
            Category oldCategory =await _categorysrv.GetDetails(id);
            if (oldCategory.CategoryId == 0)
            {
                return false;
            }
            category.CategoryId = id;
            bool status =await _categorysrv.Update(category);
            _logger.LogInformation("Update category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            bool status =await _categorysrv.Delete(id);
            _logger.LogInformation("Delete category method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}