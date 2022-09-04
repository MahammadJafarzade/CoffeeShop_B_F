using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DespinaCoffeeShop.ViewModels.Blogs
{
    public class BlogCreateVM
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string BlogImg { get; set; }
        [Required]
        public string PubishedDate { get; set; }
        [Required]
        public string Desc { get; set; }
        [NotMapped, Required]
        public IFormFile ImageFile { get; set; }
    }
}
