﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBajar.WebNew.ViewModel
{
    public class  NewCategoryViewModel
    {
        public string Name { get; set; } // ye Product ka jo name hoga

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryID { get; set; }
    }

    //public class NewCategoryViewModel
    //{

    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string ImageURL { get; set; }
    //    public bool IsFeatured { get; set; }
    //}

    public class EditCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool IsFeatured { get; set; }
    }
}