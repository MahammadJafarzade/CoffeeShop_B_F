using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Helpers;
using DespinaCoffeeShop.Models;
using DespinaCoffeeShop.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public BasketController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();
            var basket = await _context.baskets
                .Include(b=>b.basketProducts)
                .ThenInclude(bp=>bp.product)
                .FirstOrDefaultAsync(b => b.AppUserId == user.Id);
            
            var model = new BasketIndexVM();
            if (basket == null) return View(model);
            
            foreach (var dbbasketProduct in basket.basketProducts)
            {
                var basketProduct = new BasketProductVM
                {
                    Id=dbbasketProduct.Id,
                    Title=dbbasketProduct.product.Title,
                    Quantity=dbbasketProduct.Quantity,
                    StockQuantity=dbbasketProduct.product.Count,
                    Price=dbbasketProduct.product.Price
                };
                model.basketProducts.Add(basketProduct);
            }
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Add(int id,int quantity)
        {
            BasketAddVM basketAdd = new BasketAddVM()
            {
                Id = id,
                Quantity = quantity
            };
            if (!ModelState.IsValid)
            {
                 return  BadRequest(basketAdd);
            }
           var user = await _userManager.GetUserAsync(User);
           if (user == null) return Unauthorized();
            var product = await _context.Products.FindAsync(basketAdd.Id);
            if (product == null) return NotFound(); 

            var baskets = await _context.baskets.FirstOrDefaultAsync(b => b.AppUserId==user.Id);
            if (baskets == null)
            {
                baskets = new Basket
                {
                    AppUserId = user.Id
                };
                await _context.baskets.AddAsync(baskets);
                await _context.SaveChangesAsync();
            }
            var basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp=>bp.ProductId==product.Id && bp.BasketId==baskets.Id);
            if (basketProduct != null)
            {
                basketProduct.Quantity++;
            }
            else
            {
                 basketProduct = new BasketProduct
                 {
                BasketId = baskets.Id,
                ProductId = product.Id,
                Quantity=basketAdd.Quantity
                };
            await _context.BasketProducts.AddAsync(basketProduct);
            }
            await _context.SaveChangesAsync();
            return Ok(); 

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();
            var basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp=>bp.Id==id && bp.basket.AppUserId==user.Id);
            if (basketProduct==null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id ==basketProduct.ProductId);
            if (product == null) return NotFound();

             _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
