using Blog.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mappers
{
    public class UserMapper
    {
        public UserDTO ToDTO(Users user)
        {
            UserDTO dto = new UserDTO()
            {
                Name = user.Name
            };
            return dto;
        }        
    }
}
