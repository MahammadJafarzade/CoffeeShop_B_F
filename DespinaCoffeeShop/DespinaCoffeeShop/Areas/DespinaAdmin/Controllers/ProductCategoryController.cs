using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using DespinaCoffeeShop.ViewModels.PCategory;
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
        private IEnumerable<ProductCategory> productCategories;
        public ProductCategoryController(AppDbContext context)
        {
            _context = context;
            productCategories = _context.ProductCategories.Where(ct => !ct.IsDeleted);
        }
        public IActionResult Index()
        {
            return View(productCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist = productCategories.Any(ct=>ct.Name.ToLower()==category.Name.ToLower());
            if (IsExist)
            {
                ModelState.AddModelError("Name", $"{ category.Name} is exist");
                return View();
            }
            ProductCategory newCategory = new ProductCategory
            {
                Name = category.Name
            };
            await _context.ProductCategories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            ProductCategory ProductCategoryDb = _context.ProductCategories.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == id);
            if (productCategories == null)
                return NotFound(productCategories);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null)
                return BadRequest();
            ProductCategory ProductCategoryDb = _context.ProductCategories.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == id);
            if (ProductCategoryDb == null)
                return NotFound(category);
            //if (category.Name.ToLower() == categoryDb.Name.ToLower())
            //    return RedirectToAction(nameof(Index));
            bool IsExist = productCategories.Where(c => !c.IsDeleted).Any(c => c.Name.ToLower() == category.Name.ToLower() && c.Id != ProductCategoryDb.Id);
            if (IsExist)
            {
                ModelState.AddModelError("Name", $"{category.Name} is exist");
                return View();
            }
            ProductCategoryDb.Name = category.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            ProductCategory productCategoriesDb = _context.ProductCategories.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == id);
            if (productCategoriesDb == null)
                return NotFound();
            // _context.Categories.Remove(categoryDb);
            productCategoriesDb.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
