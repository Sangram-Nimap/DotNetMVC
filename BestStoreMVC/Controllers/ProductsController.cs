﻿



using BestStoreMVC.Data;
using BestStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
            // Set session
            HttpContext.Session.SetString("UserName", "Sangram");

            var products = context.Products.OrderByDescending(p => p.Id).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Optional: Set or retrieve session
            ViewBag.SessionUser = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductsDtoClass model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string uniqueFileName = null;

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            var dto = new ProductsDtoClass
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description
            };

            ViewBag.ProductId = id;
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductsDtoClass model)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = model.Name;
            product.Brand = model.Brand;
            product.Category = model.Category;
            product.Price = model.Price;
            product.Description = model.Description;

            if (model.ImageFileName != null)
            {
                string uploadFolder = Path.Combine(env.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFileName.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFileName.CopyTo(fileStream);
                }

                product.ImageFileName = uniqueFileName;
            }

            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

















/*
using BestStoreMVC.Data;
using BestStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        // GET: /Products
        public IActionResult Index()
        {
            //Adding Session
            HttpContext.Session.SetString("UserName", "Sangram");
          
            var products = context.Products.OrderByDescending(p => p.Id).ToList();
            return View(products);
        }

        // GET: /Products/Create
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        public IActionResult Create(ProductsDtoClass model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string uniqueFileName = null;

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

        // GET: /Products/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            var dto = new ProductsDtoClass
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description
            };

            ViewBag.ProductId = id;
            return View(dto);
        }

        // POST: /Products/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, ProductsDtoClass model)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = model.Name;
            product.Brand = model.Brand;
            product.Category = model.Category;
            product.Price = model.Price;
            product.Description = model.Description;

            if (model.ImageFileName != null)
            {
                string uploadFolder = Path.Combine(env.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFileName.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFileName.CopyTo(fileStream);
                }

                product.ImageFileName = uniqueFileName;
            }

            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: /Products/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}



















*//*
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






*/




















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