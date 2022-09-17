using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            ShopVM shop = new ShopVM
            {
                ProductCategory = _context.ProductCategories.Where(s =>! s.IsDeleted).Include(c=>c.Products).ToList(),
                Products=_context.Products.Where(s => !s.IsDeleted).Include(n=>n.Images).ToList()
            };
            return View(shop);
        }
        public IActionResult Detail(int id)
        {
           
            var products = _context.Products.Include(n=>n.Images).FirstOrDefault(x => x.Id == id);
            return View(products);
        }
        public IActionResult FilterforCategory(string name)
        {
            ProductVM productVM = new ProductVM ();
            //var products = _context.ProductCategories.Include(p => p.Products).ThenInclude(n=>n.Images).Where(p => !p.IsDeleted && p.Name == name).ToList();
            var productss = _context.Products.Include(p => p.Images).Where(p => !p.IsDeleted && p.ProductCategory.Name == name).ToList();
            productVM.products = productss;
            productVM.categoryName = name;
            return View(productVM);
                
        }
    }
}
