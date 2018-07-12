using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [DisplayName("Tên đăng nhập")]
        [RegularExpression(@"^[a-zA-Z0-9_]{5,255}$", ErrorMessage = "Không được chứa ký tự đặt biệt")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [DisplayName("Mật khẩu")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [RegularExpression(@"^(?=.*[\d])(?=.*[a-z])[\w\d!@#$%_]{6,40}$", ErrorMessage = "Mật khâu không đúng định dạng")]
        public string Password { get; set; }
    }
}