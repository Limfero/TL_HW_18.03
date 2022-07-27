using CarProduction.Domain;

namespace CarProduction.Dto
{
    public static class PurchaseOrderExtension
    {
        public static PurchaseOrder ConvertToPurchaseOrder(this PurchaseOrderDto purchaseOrderDto)
        {
            return new PurchaseOrder
            {
                NameBuyer = purchaseOrderDto.NameBuyer,
                DealershipId = purchaseOrderDto.DealershipId,
                CarId = purchaseOrderDto.CarId
            };
        }

        public static PurchaseOrderDto ConvertToPurchaseOrderDto(this PurchaseOrder purchaseOrder)
        {
            return new PurchaseOrderDto
            {
                NameBuyer = purchaseOrder.NameBuyer,
                DealershipId = purchaseOrder.DealershipId,
                CarId = purchaseOrder.CarId
            };
        }
    }
}
