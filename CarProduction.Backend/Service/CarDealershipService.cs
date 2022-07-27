using CarProduction.Domain;
using CarProduction.Dto;
using CarProduction.Repositories;

namespace CarProduction.Service
{
    public class CarDealershipService : ICarDealershipService
    {
        private readonly ICarDealershipRepository _carDealershipRepository;

        public CarDealershipService(ICarDealershipRepository carDealershipRepository)
        {
            _carDealershipRepository = carDealershipRepository;
        }
        public List<CarDealership> GetCarDealerships()
        {
            return _carDealershipRepository.GetAll();
        }
        public int CreateCarDealership(CarDealershipDto carDealershipDto)
        {
            if (carDealershipDto == null)
            {
                throw new Exception($"{nameof(CarDealership)} не найден");
            }

            CarDealership carDealershipEntity = carDealershipDto.ConvertToCarDealership();

            return _carDealershipRepository.CreateCarDealership(carDealershipEntity);
        }
    }
}
