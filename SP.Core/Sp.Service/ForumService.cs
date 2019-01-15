using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Repository;
using SP.Models;
namespace Sp.Service
{
    public class ForumService : IForumService
    {
        private readonly IBaseRepository<Forum> forumRepository;
        public ForumService(IBaseRepository<Forum> _forumRepository)
        {
            forumRepository = _forumRepository;
        }

        public ResponseDto CreateForum(ForumDto dto)
        {
            var newForum = new Forum { Name = dto.Name, fouderid = dto.UserId, CreateTime = DateTime.Now,AreaId=dto.AreaId };
            var forum=  forumRepository.Insert(newForum);
            if (forum.Id > 0)
            {
                return ResponseDto.Success(forum);
            }
            else
            {
                return ResponseDto.Fail("创建板块失败");
            }
        }

        public async Task<ResponseDto> CreateForumAsync(ForumDto dto)
        {
            var newForum = new Forum { Name = dto.Name, fouderid = dto.UserId, CreateTime = DateTime.Now, AreaId = dto.AreaId };
            var forum = await forumRepository.InsertAsync(newForum);
            if (forum.Id > 0)
            {
                return ResponseDto.Success(forum);
            }
            else
            {
                return ResponseDto.Fail("创建板块失败");
            }
        }

        public ResponseDto DeleteForumName(ForumDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteForumNameAsync(ForumDto dto)
        {
            throw new NotImplementedException();
        }

        public ResponseDto GetForumList(int areaId)
        {

           var forums= this.forumRepository.GetList(x => x.AreaId == areaId);
            if (forums != null)
            {
                return ResponseDto.Success(forums);
            }
            else
            {
                return ResponseDto.Fail("没有找到所属当前areaId的板块");
            }
        }

        public async Task<ResponseDto> GetForumListAsync(int areaId)
        {
            var forums = await this.forumRepository.GetListAsync(x => x.AreaId == areaId);
            if (forums != null)
            {
                return ResponseDto.Success(forums);
            }
            else
            {
                return ResponseDto.Fail("没有找到所属当前areaId的板块");
            }
        }

        public ResponseDto GetForums(int id)
        {
            var forum = this.forumRepository.Get(x => x.Id == id);
            if (forum != null)
            {
                return ResponseDto.Success(forum);
            }
            else
            {
                return ResponseDto.Fail("没有根据当前的forumId找到这个板块");
            }
        }

        public ResponseDto GetForums(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetForumsAsync(int id)
        {
            var forum = await this.forumRepository.GetAsync(x => x.Id == id);
            if (forum != null)
            {
                return ResponseDto.Success(forum);
            }
            else
            {
                return ResponseDto.Fail("没有根据当前的forumId找到这个板块");
            }
        }

        public Task<ResponseDto> GetForumsAsync(string name)
        {
            throw new NotImplementedException();
        }

        public ResponseDto UpdateForumName(ForumDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateForumNameAsync(ForumDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
