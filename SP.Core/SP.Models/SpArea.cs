using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SP.Models
{    
    /// <summary>
    /// 论坛总的板块，下面还有各种子版块
    /// </summary>
    [Table("Area")]
    public class SpArea
    {
        [Key]
        /// <summary>
        /// 区域Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        [Column("create_user_id")]
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateUserId { get; set; }


        [Column("create_time")]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
