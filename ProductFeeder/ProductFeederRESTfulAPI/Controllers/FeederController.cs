using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.DTO;

namespace ProductFeederRESTfulAPI.Controllers
{
    [ApiController,Route("api/feed")]
    public class FeederController : Controller
    {
        private readonly ProductFeederService _productFeederServices;
        private readonly IMapper _mapper;

        public FeederController(IServices<ProductFeederService> productFeederServices, IMapper mapper )
        {
            _productFeederServices = (ProductFeederService)productFeederServices;
            _mapper = mapper;
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProducts([FromBody] IEnumerable<ProductDTO> products )
        {
            List<Product> productsObjs = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<Product>>(products).ToList();
            Feed? feedCreated = null;
            try
            {
                feedCreated= await _productFeederServices.ProcessProductFeed(productsObjs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
            return Ok(feedCreated);
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetStatusFeed([FromRoute] string uid)
        {
            return Ok(await _productFeederServices.CheckStatusFeed(uid));
        }
    }
}
