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
        private readonly ICategoryService _categorysrv;
        public CategoriesController(ICategoryService categorysrv)
        {
            _categorysrv = categorysrv;
        }
        [HttpGet]
        [Route("getallcategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = _categorysrv.GetAll();
            return categories;
        }
        [HttpGet]
        [Route("getdetails/{id}")]
        public Category GetDetails(int id)
        {
            Category category = _categorysrv.GetDetails(id);
            return category;
        }
        [HttpPost]
        [Route("insert")]
        public bool Insert([FromBody] Category category)
        {
            bool status = _categorysrv.Insert(category);
            return status;
        }

        [HttpPut]
        [Route("update/{id}")]
        public bool Update(int id, [FromBody] Category category)
        {
            Category oldCategory = _categorysrv.GetDetails(id);
            if (oldCategory.CategoryId == 0)
            {
                return false;
            }
            category.CategoryId = id;
            bool status = _categorysrv.Update(category);
            return status;
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _categorysrv.Delete(id);
            return status;
        }
    }
}







