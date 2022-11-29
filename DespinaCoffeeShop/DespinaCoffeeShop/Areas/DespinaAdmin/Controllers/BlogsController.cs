using DespinaCoffeeShop.DAL;
using DespinaCoffeeShop.Helpers;
using DespinaCoffeeShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Areas.DespinaAdmin.Controllers
{
    [Area("DespinaAdmin")]
    public class BlogsController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }
        private IEnumerable<Blog> blogs;
        public BlogsController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            blogs = _context.Blogs.Where(b => !b.IsDeleted);
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
        public async Task<IActionResult> Create(Blog blogs)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!blogs.ImageFile.CheckFileSize(200))
            {
                ModelState.AddModelError("ImageFile", "Image max size must be less than 2000kb");
                return View();
            }
            if (!blogs.ImageFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("ImageFile","Type of file must be image");
                return View();
            }

            blogs.BlogImg = await blogs.ImageFile.SaveFileAsync(_env.WebRootPath, "assets","Img");
            await _context.Blogs.AddAsync(blogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var blog = _context.Blogs.Where(n=>n.Id==id).FirstOrDefault();
            if (blogs == null)
                return NotFound();

            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blogs)
        {
            if (id == null) return BadRequest();
            var blogDb = _context.Blogs.Find(id);
            if (blogDb == null)  return NotFound();
            var removePath = Utulity.GetPath(_env.WebRootPath, "assets", "Img");

            if (System.IO.File.Exists(removePath))
            {
                System.IO.File.Delete(removePath);
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!blogs.ImageFile.CheckFileSize(200))
            {
                ModelState.AddModelError("ImageFile", "Image max size must be less than 2048kb");
                return View();
            }
            if (!blogs.ImageFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("ImageFile", "Type of file must be image");
                return View();
            }
            blogDb.BlogImg = await blogs.ImageFile.SaveFileAsync(_env.WebRootPath, "assets", "Img");
            _context.Blogs.Update(blogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var blogs = _context.Blogs.Find(id);
            if (blogs == null) return NotFound();
            var path = Helper.GetPath(_env.WebRootPath, blogs.BlogImg);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
                _context.Blogs.Remove(blogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
    }
}
