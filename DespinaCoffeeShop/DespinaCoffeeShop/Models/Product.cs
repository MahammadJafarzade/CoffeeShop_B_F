using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<BasketProduct> basketProducts { get; set; }
        
    }
}
