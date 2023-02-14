using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public  int Quantity { get; set; }
        public  int BasketId { get; set; }
        public  Basket basket { get; set; }
        public int ProductId { get; set;}
        public Product product { get; set; }

    }
}
