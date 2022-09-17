using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM
            {
                Categories = _context.categories.ToList(),
                Discounts = _context.discounts.ToList(),
                menuProducts = _context.menuProducts.ToList(),
                Futures = _context.futures.ToList(),
                Shops=_context.Shops.ToList(),
                Blogs = _context.Blogs.ToList(),
                Slides=_context.Slides.ToList(),
                SocialMedias=_context.socialMedias.ToList(),
                ProductCategory=_context.ProductCategories.Where(c => !c.IsDeleted).ToList(),
                Products=_context.Products.ToList()
            };
            return View(home);
        }
    }
}
