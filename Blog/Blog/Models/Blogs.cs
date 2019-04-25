using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public partial class Blogs
    {
        public int IdBlog { get; set; }        
        public int? IdUser { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public byte? IsDraft { get; set; }

        public Users User { get; set; }
    }
}
