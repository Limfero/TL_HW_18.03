using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface IManufacturerRepository
    {
        IReadOnlyList<Manufacturer> GetAll();

        Manufacturer GetManufacturerById(int manufacturerId);
    }
}
