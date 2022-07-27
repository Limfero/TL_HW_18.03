using CarProduction.Domain;

namespace CarProduction.Dto
{
    public static class ManufacturerDtoExtension
    {
        public static Manufacturer ConvertToManufacturer(this ManufacturerDto manufacturerDto)
        {
            return new Manufacturer
            {
                ManufacturerId = manufacturerDto.ManufacturerId,
                NameFactory = manufacturerDto.NameFactory,
                Headquarters = manufacturerDto.Headquarters,
                FoundationDate = manufacturerDto.FoundationDate
            };
        }

        public static ManufacturerDto ConvertToManufacturerDto(this Manufacturer manufacturer)
        {
            return new ManufacturerDto
            {
                ManufacturerId = manufacturer.ManufacturerId,
                NameFactory = manufacturer.NameFactory,
                Headquarters = manufacturer.Headquarters,
                FoundationDate = manufacturer.FoundationDate
            };
        }
    }
}
