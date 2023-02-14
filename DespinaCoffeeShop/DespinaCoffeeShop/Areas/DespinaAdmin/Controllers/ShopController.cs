using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using DespinaCoffeeShop.ViewModels.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Areas.DespinaAdmin.Controllers
{
    [Area("DespinaAdmin")]

    public class ShopController : Controller
    {
        private AppDbContext _context { get; }
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await  _context.Products.Where(p => p.IsDeleted == false)
                .Include(p => p.Images)
                .Include(p => p.ProductCategory)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View(GetProductLists(products));
        }
        private List<ProductListVM> GetProductLists(List<Product> products)
        {
            List<ProductListVM> model = new List<ProductListVM>();
            foreach (var item in products)
            {
                var product = new ProductListVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Count = item.Count,
                    Price = item.Price,
                    ProductCategory = item.ProductCategory.Name,
                    Image = item.Images.Where(i => i.IsMain).FirstOrDefault().Url
                };
                model.Add(product);
            }
            return model;
        }
    }
}
