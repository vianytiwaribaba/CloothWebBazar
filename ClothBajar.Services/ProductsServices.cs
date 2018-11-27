using ClothBajar.DataBase;
using ClothBajar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClothBajar.Services
{
    public  class ProductsServices
    {
        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID); // Edit ka hai
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList(); // Cookie ka h 
            }
        }

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;
            using (var context = new CBContext())
            {
                //return context.Products.OrderBy(x => x.ID).Skip((pageNo-1)* pageSize).Take(pageSize).Include(x=>x.Category).ToList(); //index ka h joki hmko database se as a list la ke dega

                return context.Products.Include(x => x.Category).ToList(); //index ka h joki hmko database se as a 
            }
        }

        public void SaveProduct( Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges(); //ye create Product ko save krne ke liye 
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges(); // Edit ka hai
            }
        }


        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);

                context.Products.Remove(product);
                context.SaveChanges(); // Delete ke liye
            }
        }
    }
}
