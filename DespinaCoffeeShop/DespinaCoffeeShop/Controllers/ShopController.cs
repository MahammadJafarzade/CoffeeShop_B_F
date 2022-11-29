﻿using DespinaCoffeeShop.DAL;
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
        private int _count { get; }
        public ShopController(AppDbContext context)
        {
            _context = context;
            _count = context.Products.Where(p => !p.IsDeleted).Count();

        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _count;
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
            var products = _context.Products.Include(p => p.Images).OrderByDescending(p => p.Id).Take(9).Where(p => !p.IsDeleted && p.ProductCategory.Name == name).ToList();
            productVM.products = products;
            productVM.categoryName = name;
            return View(productVM);
        }
        public IActionResult PageProduct(string name,int skip=9)
        {
            if (skip >= _count)
            {
                return BadRequest();
            }
            var product = _context.Products.Include(p => p.Images).OrderByDescending(p => p.Id).Skip(skip).Take(9).Where(p => !p.IsDeleted && p.ProductCategory.Name == name).ToList();
            return PartialView("_ProductPartial", product);

        }
    }
}
