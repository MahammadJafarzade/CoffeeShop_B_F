using DespinaCoffeeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Menu> menuProducts { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Future> futures { get; set; }
        public DbSet<InnerMenu> innerMenu { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

    }
}
