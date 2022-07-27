using CarProduction.Domain;

namespace CarProduction.Service
{
    public interface IPurchaseOrderService
    {
        List<PurchaseOrder> GetPurchaseOrder();
    }
}
