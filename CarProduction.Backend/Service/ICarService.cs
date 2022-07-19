using CarProduction.Domain;
using CarProduction.Dto;

namespace CarProduction.Service
{
    public interface ICarService
    {
        List<Car> GetCars();
        Car GetCar(int carId);
        int CreateCar(CarDto car);
        int UpdateCar(CarDto car);
        void DeleteCar(int carId);
        List<Car> GroupFromCountOrder(int count);


    }
}
