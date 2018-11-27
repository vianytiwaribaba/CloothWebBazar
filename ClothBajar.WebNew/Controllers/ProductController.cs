using ClothBajar.Entities;
using ClothBajar.Services;
using ClothBajar.WebNew.ViewModel;
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
        CategoriesService categoryService = new CategoriesService();
        //CategoriesService categoriesService = new CategoriesService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search , int? pageNo)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();

            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value :1 : 1;

            model.Products= productsServices.GetProducts(model.PageNo);

            if (string.IsNullOrEmpty(search) == false )
            {
                model.SearchTrem = search;

                model.Products =model.Products.Where(p =>p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            
            return  PartialView(model);
        }

        [HttpGet]
        public ActionResult create()
        {
            CategoriesService categoryService = new CategoriesService();
            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = categoryService.GetCategories();

            return PartialView(model);
        }
        
        [HttpPost]
        public ActionResult create(NewProductViewModel model)
        {
            CategoriesService categoryService = new CategoriesService();

            var newProduct = new Product();

            newProduct.Name = model.Name;

            newProduct.Description = model.Description;

            newProduct.Price = model.Price;

            newProduct.Category = categoryService.GetCategory(model.CategoryID);

            newProduct.ImageURL = model.ImageURL;
            
            productsServices.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();

            var product = productsServices.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.ImageURL = product.ImageURL;
            //model.CategoryID = product.Category != null ? product.Category.ID : 0;

            model.AvailableCategories = categoryService.GetCategories();

            return  PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = productsServices.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;
            existingProduct.Category = categoryService.GetCategory(model.CategoryID);
            existingProduct.ImageURL = model.ImageURL;

            productsServices.UpdateProduct(existingProduct);
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