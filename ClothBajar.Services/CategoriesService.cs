using ClothBajar.DataBase;
using ClothBajar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBajar.Services
{
    public class CategoriesService
    {
        public Category GetCategory(int ID) // Edit ka hai
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public List<Category> GetCategories() //index ka h joki hmko database se as a list la ke dega
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }

        public void SaveCategory(Category category) //ye create category ko save krne ke liye 
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges(); // Edit ka hai
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                var category = context.Categories.Find(ID);

                context.Categories.Remove(category);
                context.SaveChanges(); // Delete ke liye
            }
        }

    }
}
