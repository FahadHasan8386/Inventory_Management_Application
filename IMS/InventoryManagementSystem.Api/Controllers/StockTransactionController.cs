using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    public class StockTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
