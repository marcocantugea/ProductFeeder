using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.DTO;
using System.Net.Mime;

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
            if (products.ToList().Count > 1000) return BadRequest();

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

        [HttpPost("products/csv")]
        public async Task<IActionResult> AddProductFromCsv([FromForm] List<IFormFile> files)
        {
            try
            {
                IList<Feed> feeds= new List<Feed>();
                foreach (IFormFile file in files)
                {
                    if (file.ContentType != "text/csv") return BadRequest();
                    if (file.Length > 10000000) return BadRequest();

                    //save the file in tmp folder

                    string fileName = $"./tmp/tmp_products_csv_{Guid.NewGuid().ToString()}.csv";
                    using (var stream = new FileStream(fileName,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    Feed? feedCreated = null;

                    try
                    {
                        feedCreated = await _productFeederServices.ProcessProductFeedCsv(fileName,_mapper);
                        feeds.Add(feedCreated);
                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                }

                return Ok(feeds);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetStatusFeed([FromRoute] string uid)
        {
            return Ok(await _productFeederServices.CheckStatusFeed(uid));
        }

        [HttpGet("{uid}/detail")]
        public async Task<IActionResult> GetDeatilFeed([FromRoute] string uid, [FromQuery] int limit=100, [FromQuery] int offset=0)
        {
            var items = new List<Product>();
            int totalItems = 0;
            try
            {
                
                items = (await _productFeederServices.GetFeedDetail(uid,limit,offset)).ToList();
                totalItems = await _productFeederServices.GetFeedTotalItemsAdded(uid);
            }
            catch (Exception)
            {
                
            }

            var response = new
            {
                totalItems = totalItems,
                data = items
            };

            return Ok(response);
        }
    }
}
