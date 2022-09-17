using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        
    }
}
