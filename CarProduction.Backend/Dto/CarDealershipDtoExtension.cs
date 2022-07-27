using CarProduction.Domain;

namespace CarProduction.Dto
{
    public static class CarDealershipDtoExtension
    {
        public static CarDealership ConvertToCarDealership(this CarDealershipDto carDealershipDto)
        {
            return new CarDealership
            {
                DealershipId = carDealershipDto.DealershipId,
                NameDealership = carDealershipDto.NameDealership,
                Supplier = carDealershipDto.Supplier
            };
        }

        public static CarDealershipDto ConvertToCarDealershipDto(this CarDealership carDealership)
        {
            return new CarDealershipDto
            {
                DealershipId = carDealership.DealershipId,
                NameDealership = carDealership.NameDealership,
                Supplier = carDealership.Supplier
            };
        }
    }
}
