using DespinaCoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels
{
    public class HomeVM
    {
        public List<Category> Categories { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Slide> Slides { get; set; }
        public List<Models.Shop> Shops { get; set; }
        public List<Future> Futures { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<InnerMenu> MenuDetails { get; set; }
        public List<Menu> menuProducts { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
        public List<Product> Products{ get; set; }
        public List<ProductVM> ProductVMs { get; set; }
    }
}

