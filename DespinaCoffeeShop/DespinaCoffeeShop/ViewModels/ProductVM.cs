using DespinaCoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels
{
    public class ProductVM
    {
        public  List<Product> products { get; set; }
        public  string categoryName { get; set; }
    }
}
