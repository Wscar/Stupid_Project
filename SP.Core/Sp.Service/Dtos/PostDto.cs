using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.Dtos
{
   public  class PostDto
    {     

        public int Id { get; set; }
         /// <summary>
         /// 板块id
         /// </summary>
        public int ForumId { get; set; }

        /// <summary>
        /// 创建用户id
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 最后回复时间
        /// </summary>
        public DateTime EndReplyTime { get; set; }


        /// <summary>
        /// 最后回复
        /// </summary>
       public string EndReplyUserNickname { get; set; }


        /// <summary>
        /// 最后回复人Id
        /// </summary>
        public  int EndReplyUserId { get; set; }

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

        public byte[] CreateUserAvatarStream { get; set; }
    }
}
