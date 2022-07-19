using CarProduction.Domain;
using CarProduction.Dto;
using CarProduction.Repositories;

namespace CarProduction.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<Car> GetCars()
        {
            return _carRepository.GetAll();
        }

        public Car GetCar(int carId)
        {
            Car car = _carRepository.GetCarById(carId);

            if(car == null)
            {
                throw new Exception($"{nameof(Car)} с Id {carId} не найден!");
            }

            return car;
        }

        public int CreateCar(CarDto carDto)
        {
            if (carDto == null)
            {
                throw new Exception($"{nameof(Car)} не найден");
            }

            Car carEntity = carDto.ConvertToCar();

            return _carRepository.CreateCar(carEntity);
        }

        public int UpdateCar(CarDto carDto)
        {
            if (carDto == null)
            {
                throw new Exception($"{nameof(Car)} не найден");
            }

            Car carEntity = carDto.ConvertToCar();

            return _carRepository.UpdateCar(carEntity);
        }

        public void DeleteCar(int carId)
        {
            Car car = _carRepository.GetCarById(carId);

            if (car == null)
            {
                throw new Exception($"{nameof(Car)} с Id {carId} не найден!");
            }

            _carRepository.DeleteCar(car);
        }

        public List<Car> GroupFromCountOrder(int count)
        {
            return _carRepository.GroupFromCountOrder(count);
        }
    }
}
