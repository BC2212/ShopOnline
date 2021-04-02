using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = new ProductDb().GetProducts(ref err);
            return View(products);
        }

        string err = string.Empty;
        int rows = 0;

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product collection)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new ProductDb().InsertUpdateProduct(ref err, ref rows, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                // TODO: Add update logic here
                var result = new ProductDb().InsertUpdateProduct(ref err, ref rows, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = new ProductDb().DeleteProduct(ref err, ref rows, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
