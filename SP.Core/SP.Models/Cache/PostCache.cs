using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Models.Cache
{
    /// <summary>
    /// 帖子缓存,任何读取帖子操作都要从缓存里面取
    /// </summary>
    public class PostCache : Post
    {
        /// <summary>
        /// 创建帖子用户的名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建贴的用户的昵称
        /// </summary>
        public string CreateUserNickname { get; set; }
         
        /// <summary>
        /// 用户头像
        /// </summary>
        public string CreateUserAvatar { get; set; }
       
        /// <summary>
        ///  评论缓存
        /// </summary>
        public  List<CommentCache> Comments { get; set; }
        public override bool Equals(object obj)
        {
            var post = obj as PostCache;
            if (post.Subject == this.Subject && this.Context == post.Context)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
