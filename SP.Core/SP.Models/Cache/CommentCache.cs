using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Models.Cache
{   
    /// <summary>
    /// 评论缓存
    /// </summary>
    public class CommentCache:Comment
    {
         
        /// <summary>
        ///  评论人用户名
        /// </summary>
        public string CommentUserName { get; set; }

        public string CommentUserNickname { get; set; }

        public string CommentUserAvatar { get; set; }
    }
}
