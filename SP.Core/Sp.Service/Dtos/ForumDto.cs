﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.Dtos
{
  public  class ForumDto
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
    }
}
