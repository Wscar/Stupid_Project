using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Models
{  

    /// <summary>
    /// 帖子表
    /// </summary>
   public  class Post
    {  
        /// <summary>
        /// 主题id
        /// </summary>
        public  int  Id { get; set; }

        /// <summary>
        ///  所属板块id
        /// </summary>
        public int  ForumId { get; set; }


        /// <summary>
        /// 创建用户id
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 是否删除(1,删除,0没有删除)
        /// </summary>
        public  int IsDelete { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
