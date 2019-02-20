using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SP.Models

{
    /// <summary>
    /// 板块
    /// </summary>
    [Table("Forum")]
    public  class Forum
    {  
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int fouderid { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
         

        [Column("operator_userid")]
        /// <summary>
        /// 操作人id，对板块进行删除更新是才会记录此Id
        /// </summary>
        public  int OperatoreUserId { get; set; }

        [Column("operator_type")]
        public int OperatType { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }
    }
}
