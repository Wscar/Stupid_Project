using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.ViewModel
{
   public class AreaVM
    {   public AreaVM()
        {
            this.ForumVMs = new List<ForumVM>();
        }
        public  int Id { get; set; }
        public  string Name { get; set; }
        public   List<ForumVM> ForumVMs { get; set; }
    }
}
