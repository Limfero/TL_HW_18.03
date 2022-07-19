using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface ICarDealershipRepository
    {
        IReadOnlyList<CarDealership> GetAll();
    }
}
