


using BestStoreMVC.Data;
using BestStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbConnection context;
        private readonly IWebHostEnvironment env;

        public ProductsController(AppDbConnection context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            var products = context.Products.OrderByDescending(p => p.Id).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductsDtoClass model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string uniqueFileName = null;

            // Save uploaded image
            if (model.ImageFileName != null)
            {
                string uploadFolder = Path.Combine(env.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFileName.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFileName.CopyTo(fileStream);
                }
            }

            // Create Product entity
            var product = new Product
            {
                Name = model.Name,
                Brand = model.Brand,
                Category = model.Category,
                Price = model.Price,
                Description = model.Description,
                ImageFileName = uniqueFileName,
                CreatedAt = DateTime.Now
            };

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}



























/*using BestStoreMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbConnection context;

        public ProductsController(AppDbConnection context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Products.OrderByDescending(p => p.Id).ToList();


            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
*/