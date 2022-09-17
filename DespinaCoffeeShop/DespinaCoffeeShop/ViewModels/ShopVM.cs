using DespinaCoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels
{
    public class ShopVM
    {
        public List<Shop> Shops { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
        public List<Product> Products { get; set; }
    }
}
