using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Services;
using ProductFeederRESTfulAPI.DTO;

namespace ProductFeederRESTfulAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private readonly SupplierServices _supplierService;

        public SupplierController(IServices<SupplierServices> supplierService)
        {
            _supplierService = (SupplierServices)supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            return Ok(await _supplierService.GetAllActiveSuppliers());
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetSupplierById([FromRoute] int id)
        {
            return Ok(await _supplierService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierDTO model, [FromServices] IMapper mapper)
        {
            Supplier newSupplier = mapper.Map<SupplierDTO, Supplier>(model);

            var response = await _supplierService.AddSupplierAsync(newSupplier);
            if (!response) return BadRequest();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] int id, [FromBody] SupplierDTO model, [FromServices] IMapper mapper)
        {
            Supplier? supplierFound = await _supplierService.GetByIdAsync(id);

            if (supplierFound == null) return UnprocessableEntity();

            mapper.Map<SupplierDTO, Supplier>(model, supplierFound);


            var response = await _supplierService.UpdateSupplierAsync(supplierFound);
            if (!response) return BadRequest();

            return Ok(supplierFound);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
        {
            var response = await _supplierService.ChangeActivationSupplierAsync(id, false);
            if (!response) return BadRequest();

            return NoContent();
        }

        [HttpGet("{id}/brands")]
        public async Task<IActionResult> GetSupplierWithBrands([FromRoute] int id)
        {
            return Ok(await _supplierService.GetSupplierWithBrands(id));
        }
    }
}
