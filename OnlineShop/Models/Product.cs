using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        [DisplayName("Ảnh")]
        public string ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [DisplayName("Loại sản phẩm")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public Product()
        {
            ImageData = "default.png";
        }

    }
}