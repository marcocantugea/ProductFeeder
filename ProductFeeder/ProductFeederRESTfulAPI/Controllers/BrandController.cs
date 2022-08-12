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
    public class BrandController : ControllerBase
    {
        private readonly BrandsServices _brandServices;

        public BrandController(IServices<BrandsServices> brandService)
        {
            _brandServices= (BrandsServices)brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await _brandServices.GetActiveBrands());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand([FromRoute] int id)
        {
            return Ok(await _brandServices.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandDTO model, [FromServices] IMapper mapper)
        {
            Brand newBrand = mapper.Map<BrandDTO, Brand>(model);
            var response=  await _brandServices.AddBrandAsync(newBrand);
            if (!response) return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand([FromRoute] int id, [FromBody] BrandDTO model,[FromServices] IMapper mapper)
        {
            model.supplierId = id;
            Brand? brandFound = await _brandServices.GetByIdAsync(id);
            if(brandFound==null) return BadRequest();

            mapper.Map<BrandDTO,Brand>(model,brandFound);

            var response = await _brandServices.UpdateBrandAsync(brandFound);
            if (!response) return BadRequest();

            return Ok(brandFound);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelteBrand([FromRoute] int id)
        {
            var response= await _brandServices.ChangeActivationBrandAsync(id,false);
            if (!response) return BadRequest();

            return NoContent();
        }

    }
}
