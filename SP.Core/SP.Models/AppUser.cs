using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SP.Models
{  
    [Table("app_user")]
  public  class AppUser
    {
        public  int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        [Column("register_time")]
        public DateTime RegisterTime { get; set; }
        public string Avatar { get; set; }
    }
}
