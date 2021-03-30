using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Comments
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="مطلوب")]
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
