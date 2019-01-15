using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
namespace Sp.Service
{
    public interface IPostService
    {   
        /// <summary>
        /// 通过板块id来获取下面的帖子
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        ResponseDto GetPostByForumId(int forumId);
        ResponseDto GetPostByFormUserId(int userId);
        ResponseDto GetPostByAreaId(int areaId);
        ResponseDto UpdatePost(PostDto dto);
        ResponseDto DeltePost(int postId);
        ResponseDto CreatePost(PostDto dto);
        Task<ResponseDto> GetPostByFormIdAsync(int forumId);
        Task<ResponseDto> GetPostByFormUserIdAsync(int userId);
        Task<ResponseDto> GetPostByAreaIdAsync(int areaId);
        Task<ResponseDto> UpdatePostAsync(PostDto dto);
        Task<ResponseDto> DeltePostAsync(int postId);
        Task<ResponseDto> CreatePostAsync(PostDto dto);
    }
}
