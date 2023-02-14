using DespinaCoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DespinaCoffeeShop.ViewModels
{
    public class ShopVM
    {

        public List<Models.Shop> Shops { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
        public List<Product> Products { get; set; }
        public int Page { get; set; }
        public int Take { get; set; }
        public int PageCount { get; set; }
    }
}
