using Microsoft.AspNetCore.Mvc;
using CarProduction.Service;
using CarProduction.Dto;
using CarProduction.Domain;

namespace CarProduction.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("{manufacturerId}")]
        public IActionResult GetManufacturer(int manufacturerId)
        {
            try
            {
                return Ok(_manufacturerService.GetManufacturer(manufacturerId).ConvertToManufacturerDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
