using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            ProductVM product = new ProductVM
            {
                Products = _context.Products.Where(m =>!m.IsDeleted).ToList()
            };
            return View(product);
        }
    }
}
