using Microsoft.AspNetCore.Mvc;
using Vidly.Data;

namespace Vidly.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly AppDbConnection context;

        public CategoryController1(AppDbConnection context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            var result = context.CategoryMaster.ToList();

            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryMaster model)
        {
            if (ModelState.IsValid)
            {
                var cat = new CategoryMaster()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                };
                context.CategoryMaster.Add(cat);
                context.SaveChanges();
                TempData["Error"] = "Record saved sucessfull!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Empty field cannot submit";
                return View(model);
            }
        }
        public ActionResult Delete(int? id)
        {
            var cat = context.CategoryMaster.SingleOrDefault(e => e.CategoryId == id);
            context.CategoryMaster.Remove(cat);
            context.SaveChanges(true);
            TempData["Error"] = "Record Deleted sucessfull!";
            return RedirectToAction("Index");
        }
    }
}
