using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.Authentication
{
    public class UserDto
    {
        public  int Id { get; set; }
        public  string NickName { get; set; }
        public  string Avatar { get; set; }
        public  List<string > Roles { get; set; }
     }
}
