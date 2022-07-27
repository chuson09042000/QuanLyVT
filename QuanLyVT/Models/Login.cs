using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyVT.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Bạn cần nhập tài khoản!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}