using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.DTO;

namespace ProductFeederRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsServices _productService;
        public ProductController(IServices<ProductsServices> productService)
        {
            _productService=(ProductsServices)productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int limit = 100, [FromQuery] int offset=0)
        {
            return Ok(await _productService.GetProductsAsync(limit,offset));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO model, [FromServices] IMapper mapper )
        {
            Product newProduct = mapper.Map<ProductDTO, Product>(model);
            var response= await _productService.AddProductAsync(newProduct);

            if(!response) return BadRequest();
            return NoContent();
        }
    }
}
