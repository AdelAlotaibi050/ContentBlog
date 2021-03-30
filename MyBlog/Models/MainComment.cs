using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public class MainComment:Comments
    {
        public List<SubComment> SubComments { get; set; }
    }
}
