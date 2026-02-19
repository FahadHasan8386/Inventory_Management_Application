using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
