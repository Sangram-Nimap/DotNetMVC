using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers
{
    public class ProductMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
