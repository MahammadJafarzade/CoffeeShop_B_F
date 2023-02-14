using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels.Basket
{
    public class BasketIndexVM
    {
        public BasketIndexVM()
        {
            basketProducts = new List<BasketProductVM>();
        }
        public List<BasketProductVM> basketProducts { get; set; }
    }
}
