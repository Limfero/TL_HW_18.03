using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        List<Car> GetCarByManufacturerId(int manufacturerId);
        List<Car> GroupFromCountOrder(int count);
        Car GetCarById(int carId);
        int UpdateCar(Car car);
        void DeleteCar(Car car);
        int CreateCar(Car car);
    }
}
