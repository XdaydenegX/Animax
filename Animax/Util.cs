using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;

namespace Animax
{
    public class Util
    { 
        private static AnimaxEntities animax = new AnimaxEntities();

        public static User GetUserByLogin(string email, string password)
        {

            return animax.User.FirstOrDefault(user => user.email == email && user.password == password);

        }

        public static void createUser(string name, string surname, string email, string password)
        {
            animax.User.Add(new User() { name = name, surname = surname, email = email, password = password });
            animax.SaveChanges();
        }

        public static bool isUserExists(string email)
        {
            return animax.User.Any(user => user.email == email);

        }


        public static List<Product> GetProduct()
        {

            List<Product> data = animax.Product.ToList();

            return data;
        }

        public static List<Banners> GetBanners()
        {
            return animax.Banners.ToList();
        }       

        
        public static List<string> GetallCategory()
        {
            return animax.Category.Select(c => c.name).ToList();
        }

        public static List<Product> getProductsByCategory(string category_name)
        {
            var _category = animax.Category.FirstOrDefault(category => category.name == category_name);
            var category_id = _category.id;
            return animax.Product.Where(i => i.Category_Product.Any(j => j.category_id == category_id)).ToList();
        }

    }
}
