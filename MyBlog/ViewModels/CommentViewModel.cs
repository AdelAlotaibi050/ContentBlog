using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int PostID { get; set; }
        [Required]
        public int MainCommentId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
