using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductCategory> Pcategories = await _context.ProductCategories.Where(s => !s.IsDeleted).Include(c => c.Products).ToListAsync();
            return View(Pcategories);       
        }
    }
}
