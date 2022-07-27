using CarProduction.Domain;
using CarProduction.Dto;

namespace CarProduction.Service
{
    public interface ICarDealershipService
    {
        List<CarDealership> GetCarDealerships();
        int CreateCarDealership(CarDealershipDto carDealershipDto);
    }
}
