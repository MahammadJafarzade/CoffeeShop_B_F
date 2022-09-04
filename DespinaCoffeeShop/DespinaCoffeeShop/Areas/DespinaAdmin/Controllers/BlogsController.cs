using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Models;
using DespinaCoffeeShop.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Areas.DespinaAdmin.Controllers
{
        [Area("DespinaAdmin")]
    public class BlogsController : Controller
    {
        private AppDbContext _context { get; }
        private IEnumerable<Blog> blogs;
        public BlogsController(AppDbContext context)
        {
            _context = context;
            blogs=_context.Blogs.Where(b => !b.IsDeleted);
        }
        public IActionResult Index()
        {
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogCreateVM blogs)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return Content("Oo");
        }
    }
}
