using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Loại sản phẩm")]
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}