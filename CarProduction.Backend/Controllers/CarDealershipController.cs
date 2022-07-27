using CarProduction.Service;
using CarProduction.Dto;
using CarProduction.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarProduction.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class CarDealershipController : ControllerBase
    {
        private readonly ICarDealershipService _carDealershipService;

        public CarDealershipController(ICarDealershipService carDealershipService)
        {
            _carDealershipService = carDealershipService;
        }

        [HttpGet]
        [Route("listCarDealerships")]
        public IActionResult GetCarDealership()
        {
            try
            {
                return Ok(_carDealershipService.GetCarDealerships()
                    .ConvertAll(t => t.ConvertToCarDealershipDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createCarDealerships")]
        public IActionResult CreateCarDealership([FromBody] CarDealershipDto carDealershipDto)
        {
            try
            {
                return Ok(_carDealershipService.CreateCarDealership(carDealershipDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
