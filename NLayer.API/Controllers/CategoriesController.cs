using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Service.Services.Abstract;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryByIdWithProduct(int id) 
        {
            return CreateActionResult(await _service.GetCategoryByIdWithProductAsync(id));
        }
    }
}
