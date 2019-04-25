using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{    
    public class BlogDTO
    {
        public int IdBlog { get; set; }
        public int? IdUser { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public byte? IsDraft { get; set; }

        public UserDTO User { get; set; }
    }
}
