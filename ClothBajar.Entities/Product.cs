using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBajar.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }

        public virtual Category Category { get; set; } //category ko reference kiya hua h to product kisi category lo belong kregi

        public string ImageURL { get; set; }

    }
}
