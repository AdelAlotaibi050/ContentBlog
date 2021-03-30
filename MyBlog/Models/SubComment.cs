using System;
namespace MyBlog.Models
{
    public class SubComment:Comments
    {
        public int MainCommentId { get; set; }
    }
}
