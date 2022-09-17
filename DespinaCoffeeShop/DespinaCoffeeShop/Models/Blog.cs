using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BlogImg { get; set; }
        public string PubishedDate { get; set; }
        public string Desc { get; set; }
        [NotMapped,Required]
        public IFormFile ImageFile { get; set; }
        public bool IsDeleted { get; set; }
    }
}
