using BestStoreMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ProductsController1 : Controller
    {
        private readonly AppDbConnection context;

        public ProductsController1(AppDbConnection context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();


            return View(products);
        }
    }
}
