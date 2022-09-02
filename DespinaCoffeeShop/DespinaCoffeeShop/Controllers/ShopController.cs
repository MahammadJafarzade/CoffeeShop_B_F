using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
                ProductCategory = _context.ProductCategories.Where(s =>! s.IsDeleted).ToList()
            };
            return View(shop);
        }
        public IActionResult Detail(int id)
        {
            var shops = _context.Shops.FirstOrDefault(x => x.Id == id);

            return View(shops);
        }
    }
}
