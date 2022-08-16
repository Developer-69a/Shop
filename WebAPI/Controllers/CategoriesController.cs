using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("Add")]
        public async Task<ActionResult> Add(Category category)
        {
           var result = await _categoryService.AddAsync(category);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpGet("Search")]
        public async Task<ActionResult> Search(string search) 
        { 
            var result= await _categoryService.SearchAsync(search);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("GetList")]
        public async Task<ActionResult> GetList()
        {
            var result=await _categoryService.GetListAsync();
            return result.Success ? Ok(result):BadRequest(result.Message);
        }
    }
}
