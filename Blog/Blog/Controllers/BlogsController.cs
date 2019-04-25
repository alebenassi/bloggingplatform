using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Mappers;
using DTO;

namespace Blog.Controllers
{
    [Route("api/[controller]")]    
    public class BlogsController : Controller
    {
        
        private BlogContext _context;
        private UserMapper _userMapper = new UserMapper();
        private BlogMapper _blogMapper = new BlogMapper();

        public BlogsController()
        {
            this._context = new BlogContext();            
        }
        
        [HttpGet]        
        public List<BlogDTO> Get()
        {            
            var blogs = _context.Blogs.Include(x=> x.User).ToList();
            List<BlogDTO> list = new List<BlogDTO>();
            foreach (var b in blogs)
            {
                var bl = _blogMapper.ToDTO(b);
                bl.User = _userMapper.ToDTO(b.User);
                list.Add(bl);
            }
            return list;
        }
        
        [HttpGet("{id}")]
        public BlogDTO Get(int id)
        {
            Blogs blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return null;
            } else
            {
                return _blogMapper.ToDTO(blog);
            }
            
        }

        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] BlogDTO blogDTO)
        {
            try
            {
                Blogs blog = _blogMapper.ToModel(blogDTO);
                _context.Blogs.Add(blog);
                _context.SaveChanges();                
                return new JsonResult(new { response = true, message = "Entry created" });
            }
            catch (Exception e)
            {                
                return new JsonResult(new { response = false, message = "Failed" });
            }
        }

        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] BlogDTO blogDTO)
        {
            if (id != blogDTO.IdBlog)
            {                
                return new JsonResult(new { response = false, message = "Failed" });
            }

            Blogs blog = _blogMapper.ToModel(blogDTO);
            _context.Entry(blog).State = EntityState.Modified;
            _context.SaveChanges();
            
            return new JsonResult(new { response = true, message = "Entry edited" });
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var blog = _context.Blogs.Find(id);

            if (blog == null)
            {
                return new JsonResult(new { response = false, message = "Failed" });
            }

            _context.Blogs.Remove(blog);
            _context.SaveChanges();

            return new JsonResult(new { response = true, message = "Entry deleted" });
        }
    }
}