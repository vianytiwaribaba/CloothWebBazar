using ClothBajar.DataBase;
using ClothBajar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBajar.Services
{
    public class ConigurationsServices
    {
        public Config GetConfig(string key)
        {
            using (var context = new CBContext())
            {
                return context.Configurations.Find(key);
            }
        }
    }
}
