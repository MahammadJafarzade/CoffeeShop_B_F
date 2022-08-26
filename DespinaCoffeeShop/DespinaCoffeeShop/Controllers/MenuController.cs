using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    public class MenuController:Controller
    {
      
        private readonly AppDbContext _context;
        public MenuController(AppDbContext context)
        {
            _context = context;
           
        }
        public IActionResult MenuDetail()
        {
            MenuVM menu = new MenuVM
            {
                menuProducts = _context.menuProducts.Where(m => m.IsDeleted).ToList()
            };
            return View(menu);
        }
    }
}
