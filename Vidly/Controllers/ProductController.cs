using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbConnection context;

        public ProductController(AppDbConnection context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            return View(this.GetCustomers(1));
        }


        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            return View(this.GetCustomers(currentPageIndex));
        }

        private ProductListsModel GetCustomers(int currentPage)
        {
            int maxRows = 10;

            ProductListsModel productList = new ProductListsModel();


            productList.ProductData = (from Prod in entities.ProductMaster
                                       join Cat in entities.CategoryMaster on Prod.CategoryId equals Cat.CategoryId
                                       select new Products { ProductId = Prod.ProductId, ProductName = Prod.ProductName, CategoryId = Cat.CategoryId, CategoryName = Cat.CategoryName })
                        .OrderBy(Prod => Prod.ProductId)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)entities.ProductMaster.Count() / Convert.ToDecimal(maxRows));
            productList.PageCount = (int)Math.Ceiling(pageCount);

            productList.CurrentPageIndex = currentPage;

            return productList;


        }
    }
}