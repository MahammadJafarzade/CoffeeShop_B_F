using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels.Basket
{
    public class BasketProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [NotMapped, Required]
        public IFormFile ImageFile { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
    }
}
