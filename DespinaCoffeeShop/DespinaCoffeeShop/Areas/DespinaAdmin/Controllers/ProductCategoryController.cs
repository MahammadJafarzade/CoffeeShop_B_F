using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Areas.DespinaAdmin.Controllers
{
    [Area("DespinaAdmin")]
    public class ProductCategoryController : Controller
    {
        private AppDbContext _context { get; }
        public ProductCategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.ProductCategories.Where(ct=>!ct.IsDeleted));
        }
    }
}
