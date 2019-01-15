using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.Dtos
{
   public  class PostDto
    {
        public int ForumId { get; set; }
        public int CreateUserId { get; set; }
        public string Subject { get; set; }
        public string Context { get; set; }
      
    }
}
