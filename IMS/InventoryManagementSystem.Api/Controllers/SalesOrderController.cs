using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers
{
    public class SalesOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
