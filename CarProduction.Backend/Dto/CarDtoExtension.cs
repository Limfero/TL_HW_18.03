using CarProduction.Domain;

namespace CarProduction.Dto
{
    public static class CarDtoExtension
    {
        public static Car ConvertToCar(this CarDto carDto)
        {
            return new Car
            {
                CarId = carDto.CarId,
                Model = carDto.Model,
                BuildData = carDto.BuildData,
                Price = carDto.Price,
                ManufacturerId = carDto.ManufacturerId
            };
        }

        public static CarDto ConvertToCarDto(this Car car)
        {
            return new CarDto
            {
                CarId = car.CarId,
                Model = car.Model,
                BuildData = car.BuildData,
                Price = car.Price,
                ManufacturerId = car.ManufacturerId
            };
        }
    }
}
