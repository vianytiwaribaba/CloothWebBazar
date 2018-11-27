using ClothBajar.Services;
using ClothBajar.WebNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBajar.WebNew.Controllers
{
    public class ShopController : Controller
    {
        ProductsServices productsServices = new ProductsServices();

        // GET: Shop
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();

            var CartProductsCookie = Request.Cookies["cartproducts"];

            if (CartProductsCookie != null)
            {
                //var productIDs = CartProductsCookie.Value;

                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIds = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = productsServices.GetProducts(model.CartProductIds);
            }
            return View(model);
        }
    }
}