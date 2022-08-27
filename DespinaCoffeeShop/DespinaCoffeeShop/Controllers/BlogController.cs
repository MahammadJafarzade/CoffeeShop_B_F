using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            BlogVM blogs = new BlogVM
            {
                Blogs = _context.Blogs.Where(m =>! m.IsDeleted).ToList()
            };
            return View(blogs);
        }
        
        public IActionResult Detail(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            return View(blog);
        }
    }
}
