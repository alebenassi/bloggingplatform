using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Users
    {
        public Users()
        {
            Blogs = new HashSet<Blogs>();
        }

        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
    }
}
