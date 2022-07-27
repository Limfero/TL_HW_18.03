using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface IPurchaseOrderRepository
    {
        List<PurchaseOrder> GetAll();
    }
}
