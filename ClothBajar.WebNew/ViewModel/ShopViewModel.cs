using ClothBajar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBajar.WebNew.ViewModel
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts { get; set;}

        public List<int> CartProductIds { get; set; }
    }
}