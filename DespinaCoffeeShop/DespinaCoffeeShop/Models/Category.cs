using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
