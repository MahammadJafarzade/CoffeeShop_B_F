using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
