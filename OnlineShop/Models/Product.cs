using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public Product()
        {
            ImageData = "default.png";
        }

    }
}