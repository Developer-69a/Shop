using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bussines.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotographiesController : ControllerBase
    {
        private readonly IProductPhotographyService _productPhotographyService;

        public ProductPhotographiesController(IProductPhotographyService productPhotographyService)
        {
            _productPhotographyService = productPhotographyService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(IFormFile file,int productId)
        {
            var result = await _productPhotographyService.AddAsync(file,productId);
            return result.Success? Ok(result) : BadRequest(result.Message);
        }
      
    }
}
