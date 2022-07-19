using CarProduction.Domain;

namespace CarProduction.Repositories
{
    public interface IPurchaseOrderRepository
    {
        IReadOnlyList<PurchaseOrder> GetAll();
    }
}
