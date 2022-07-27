using CarProduction.Domain;
using CarProduction.Dto;

namespace CarProduction.Service
{
    public interface IManufacturerService
    {
        Manufacturer GetManufacturer(int manufacturerId);
    }
}
