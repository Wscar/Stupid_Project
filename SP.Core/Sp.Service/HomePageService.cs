using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Models;
using SP.Repository;
using System.Linq;
using Sp.Service.ViewModel;
namespace Sp.Service
{
    public class HomePageService : IHomePageService
    {
        private readonly BaseRepository<SpArea> baseRepository;
        private readonly IBaseRepository<Forum> forumRepository;
        private readonly IBaseRepository<Post>  postReposiyory;
        private readonly IBaseRepository<AppUser> userRepository;
        public HomePageService(IBaseRepository<SpArea> _baseRepository, 
                               IBaseRepository<Forum> _forumRepository,
                               IBaseRepository<Post> _postRepository,
                               IBaseRepository<AppUser> _userRepository)
        {
            baseRepository = _baseRepository as BaseRepository<SpArea>;
            forumRepository = _forumRepository;
            postReposiyory = _postRepository;
            userRepository = _userRepository;
        }
        public ResponseDto GetHomePageAreaAndForums()
        {

            var result = baseRepository.ExecuteSql("getAreaAndForums");
            if (result != null)
            {
                return ResponseDto.Success(result);
            }
            else
            {
                return ResponseDto.Fail("获取首页的区域和板块是失败");
            }
        }

        public async Task<ResponseDto> GetHomePageAreaAndForumsAsync()
        {
            ResponseDto responseDto = null;
            try
            {
                var areas = await this.baseRepository.GetListAsync();
                List<AreaVM> areaVMs = new List<AreaVM>();
                foreach (var item in areas)
                {
                    AreaVM areaVm = new AreaVM { Id = item.Id, Name = item.Name };
                    var forums = await forumRepository.GetListAsync(x => x.AreaId == item.Id);

                    if (forums != null)
                    {
                        areaVm.ForumVMs = forums.Select(x => new ForumVM { Id = x.Id, Name = x.Name, AreaId = x.AreaId }).ToList();
                    }
                    areaVMs.Add(areaVm);
                }
                if (areaVMs.Count > 0)
                {
                    return ResponseDto.Success(areaVMs);
                }
            }catch(Exception e)
            {
                responseDto = ResponseDto.Fail(e.Message);
            }

            return responseDto;
        }

        public async  Task<ResponseDto> GetHomePageAsync()
        {
            var result = await postReposiyory.GetPageAsync<DateTime>(x => x.IsDelete == 0, 1, 20, p => p.CreateTime);
            if (result != null)
            {
                 
                return ResponseDto.Success(result);
            }
            else
            {
                return ResponseDto.Fail("");
            }
        }

        public ResponseDto GetHomePagePosts()
        {
            throw new NotImplementedException();
        }
        private   Task<List<PostDto>> MappingToPostDtoAsync(List<Post> posts)
        {
                   
            return null;
        }
    }
}
