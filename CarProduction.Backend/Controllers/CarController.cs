using CarProduction.Service;
using CarProduction.Dto;
using CarProduction.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarProduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("listCar")]
        public IActionResult GetCars()
        {
            try
            {
                return Ok(_carService.GetCars()
                    .ConvertAll(t => t.ConvertToCarDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{carId}")]
        public IActionResult GetCar(int carId)
        {
            try
            {
                return Ok(_carService.GetCar(carId).ConvertToCarDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createCar")]
        public IActionResult CreateCar([FromBody] CarDto carDto)
        {
            try
            {
                return Ok(_carService.CreateCar(carDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{carId}/delete")]
        public IActionResult DeleteCar(int carId)
        {
            try
            {
                _carService.DeleteCar(carId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{carId}/update")]
        public IActionResult UpdateCar([FromBody] CarDto carDto)
        {
            try
            {
                return Ok(_carService.UpdateCar(carDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("groupFromCountOrder/{count}")]
        public IActionResult GroupFromCountOrder(int count)
        {
            try
            {
                return Ok(_carService.GroupFromCountOrder(count));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
