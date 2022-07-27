using Microsoft.AspNetCore.Mvc;
using CarProduction.Service;
using CarProduction.Dto;

namespace CarProduction.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        [Route("listPurchaseOrder")]
        public IActionResult PurchaseOrder()
        {
            try
            {
                return Ok(_purchaseOrderService.GetPurchaseOrder()
                    .ConvertAll(t => t.ConvertToPurchaseOrderDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
