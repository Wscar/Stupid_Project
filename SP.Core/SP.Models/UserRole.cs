using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SP.Models
{  
    [Table("Role")]
   public class UserRole
    {
      public  int Id { get; set; }
      public  int UserId { get; set; }
      public string Type { get; set; }
       
    }
}
