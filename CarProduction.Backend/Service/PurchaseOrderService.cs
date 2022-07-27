using CarProduction.Repositories;
using CarProduction.Domain;

namespace CarProduction.Service
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public List<PurchaseOrder> GetPurchaseOrder()
        {
            return _purchaseOrderRepository.GetAll();
        }
    }
}
