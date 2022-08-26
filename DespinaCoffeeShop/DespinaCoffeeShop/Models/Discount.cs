using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Discdescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
