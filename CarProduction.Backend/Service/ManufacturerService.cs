using CarProduction.Domain;
using CarProduction.Repositories;

namespace CarProduction.Service
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufactererRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufactererRepository = manufacturerRepository;
        }

        public Manufacturer GetManufacturer(int manufacturerId)
        {
            Manufacturer manufacturer = _manufactererRepository.GetManufacturerById(manufacturerId);

            if (manufacturer == null)
            {
                throw new Exception($"{nameof(Manufacturer)} с Id {manufacturerId} не найден!");
            }

            return manufacturer;
        }
    }
}
