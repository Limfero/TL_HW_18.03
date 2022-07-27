using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface ICarDealershipRepository
    {
        List<CarDealership> GetAll();

        int CreateCarDealership(CarDealership carDealership);
    }
}
