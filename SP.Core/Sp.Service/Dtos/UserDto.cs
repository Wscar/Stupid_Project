using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.Dtos
{
   public class UserDto
    {   
        public UserDto()
        {
            Roles = new List<string>();
        }
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public List<string> Roles { get; set; }
    }
}
