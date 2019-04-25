using Blog.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mappers
{
    public class BlogMapper
    {
        public BlogDTO ToDTO(Blogs blog)
        {
            BlogDTO dto = new BlogDTO()
            {
                IdBlog = blog.IdBlog,
                IdUser = blog.IdUser,
                IsDraft = blog.IsDraft,
                Text = blog.Text,
                Title = blog.Title                
            };
            return dto;
        }

        public Blogs ToModel(BlogDTO blogDTO)
        {
            Blogs blogs = new Blogs()
            {
                IdBlog = blogDTO.IdBlog,
                IdUser = blogDTO.IdUser,
                IsDraft = blogDTO.IsDraft,
                Text = blogDTO.Text,
                Title = blogDTO.Title       
            };
            return blogs;
        }
    }
}
