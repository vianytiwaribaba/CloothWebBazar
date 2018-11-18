using ClothBajar.Entities;
using ClothBajar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBajar.WebNew.Controllers
{
  
    public class ProductController : Controller
    {
        ProductsServices productsServices = new ProductsServices();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            var products = productsServices.GetProducts();

            if (string.IsNullOrEmpty(search) == false )
            {
                products = products.Where(p =>p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            
            return  PartialView(products);
        }

        [HttpGet]
        public ActionResult create()
        {
            return PartialView();
        }
        
        [HttpPost]
        public ActionResult create(Product product)
        {
            productsServices.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsServices.GetProduct(ID);

            return  PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsServices.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsServices.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}