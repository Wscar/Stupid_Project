using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
namespace Sp.Service
{
   public interface IForumService
    {
         ResponseDto CreateForum(ForumDto dto);
         ResponseDto UpdateForumName(ForumDto dto);
         ResponseDto DeleteForumName(ForumDto dto);
         ResponseDto GetForums(int id);
         ResponseDto GetForums(string name);
         ResponseDto GetForumList(int areaId);
        Task<ResponseDto> GetForumsAsync(int id);
        Task<ResponseDto> GetForumsAsync(string name);
        Task<ResponseDto> GetForumListAsync(int areaId);
        Task<ResponseDto> CreateForumAsync(ForumDto dto);
        Task<ResponseDto> UpdateForumNameAsync(ForumDto dto);
        Task<ResponseDto> DeleteForumNameAsync(ForumDto dto);
    }
}
