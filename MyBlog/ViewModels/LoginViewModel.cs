using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="اسم المستخدم مطلوب")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="كلمة المرور مطلوبة")]
        public string Password { get; set; }
    }
}
