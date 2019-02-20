using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SP.Models
{  
    /// <summary>
    /// 评论表
    /// </summary>
  public  class Comment
    {
        [Key]
        /// <summary>
        /// 评论Id
        /// </summary>
        public  int Id { get; set; }
 
        /// <summary>
        /// 所属帖子id
        /// </summary>
        public  int PostId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public  string Context { get; set; }

        /// <summary>
        /// 评论人Id
        /// </summary>
        public int CommentUserId { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public  DateTime CommentTime { get; set; }
    }
}
