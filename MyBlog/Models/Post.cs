using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage ="مطلوب")]
        
        public string Body { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public List<MainComment> MainComments { get; set; }
    }
}
