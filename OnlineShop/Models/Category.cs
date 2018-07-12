﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}