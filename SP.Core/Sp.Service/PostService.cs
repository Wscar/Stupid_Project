using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Models;
using SP.Repository;
using SP.Models.Cache;

namespace Sp.Service
{
    public class PostService : IPostService
    {
        private readonly IBaseRepository<Post> baseRepository;
        private readonly  ICacheService<PostCache> postCacheService;
        private readonly IImageRepository imageRepository;
        public PostService(IBaseRepository<Post> _baseRepository, ICacheService<PostCache> _postCacheService, IImageRepository _imageRepository)
        {
            baseRepository = _baseRepository;
            postCacheService = _postCacheService;
            imageRepository = _imageRepository;
        }
        public ResponseDto CreatePost(PostDto dto)
        {
            var newPost = new Post
            {
                CreateUserId = dto.CreateUserId,
                CreateTime = DateTime.Now,
                ForumId = dto.ForumId,
                Subject = dto.Subject,
                Context = dto.Context
            };
          var post=  baseRepository.Insert(newPost);
            if (post != null)
            {
                dto.Id = post.Id;
                this.postCacheService.AddCache(this.Mapping(dto));
                return ResponseDto.Success(post);
            }
            else
            {
                return ResponseDto.Fail("创建失败");
            }
        }
        public async Task<ResponseDto> CreatePostAsync(PostDto dto)
        {                
            var newPost = new Post
            {
                CreateUserId = dto.CreateUserId,
                CreateTime = DateTime.Now,
                ForumId = dto.ForumId,
                Subject = dto.Subject,
                Context = dto.Context,
                EndReplyTime = DateTime.Now,
                EndReplyUserId=dto.CreateUserId,              
                
            };
            var post = await baseRepository.InsertAsync(newPost);
            if (post != null)
            {
                var userAvatartStream = await imageRepository.DownLoadImageAsync(dto.CreateUserAvatar);
                dto.Id = post.Id;
                dto.EndReplyUserId = post.CreateUserId;               
                dto.EndReplyTime = post.EndReplyTime;
                dto.EndReplyUserNickname = dto.CreateUserNickname;
                dto.CreateUserAvatarStream = userAvatartStream;
                await this.postCacheService.AddCacheAsync(this.Mapping(dto));
                return ResponseDto.Success(null);
            }
            else
            {
                return ResponseDto.Fail("创建失败");
            }
        }

        public ResponseDto DeltePost(int postId)
        {
            var post = baseRepository.Get(x => x.Id == postId);
            if (post != null)
            {
                baseRepository.Delete(post);
                return ResponseDto.Success(null);
            }
            else
            {
                return ResponseDto.Fail("找不到当前的帖子");
            }
        }

        public async Task<ResponseDto> DeltePostAsync(int postId)
        {
            var post = await baseRepository.GetAsync(x => x.Id == postId);
            if (post != null)
            {
                await baseRepository.DeleteAsync(post);
                return ResponseDto.Success(null);
            }
            else
            {
                return ResponseDto.Fail("找不到当前的帖子");
            }
        }
        public ResponseDto GetPagePost(int forumId, int pageIndex, int pageCount, bool isReturnCache = true)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetPagePostAsync(int forumId, int pageIndex, int pageCount, bool isReturnCache = true)
        {
            try
            {
                if (isReturnCache)
                {
                    var cachesResult = await this.postCacheService.GetPageCacheAsync(forumId, pageIndex, pageCount);
                    return ResponseDto.Success(cachesResult);
                }
                else
                {
                     //采用视图的方式进行查询
                }
                return ResponseDto.Fail("查询帖子错误");
            }
            catch(Exception ex)
            {
                return ResponseDto.Fail(ex.Message);
            }
            finally
            {
              
            }
            
        }

        public ResponseDto GetPostByAreaId(int areaId)
        {
            //此方法有争议
            return null;
        }

        public Task<ResponseDto> GetPostByAreaIdAsync(int areaId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetPostByFormIdAsync(int forumId)
        {
            var posts = await baseRepository.GetPageAsync<DateTime>(x => x.ForumId == forumId, 1, 20, x => x.CreateTime);
            if (posts != null)
            {
                return ResponseDto.Success(posts);
            }
            else
            {
                return ResponseDto.Fail("没有找到");
            }
        }

        public ResponseDto GetPostByFormUserId(int userId)
        {
            var posts =  baseRepository.GetPage<DateTime>(x => x.CreateUserId==userId, 1, 20, x => x.CreateTime);
            if (posts != null)
            {
                return ResponseDto.Success(posts);
            }
            else
            {
                return ResponseDto.Fail("没有找到");
            }
        }

        public async Task<ResponseDto> GetPostByFormUserIdAsync(int userId)
        {
            var posts = await baseRepository.GetPageAsync<DateTime>(x => x.CreateUserId == userId, 1, 20, x => x.CreateTime);
            if (posts != null)
            {
                return ResponseDto.Success(posts);
            }
            else
            {
                return ResponseDto.Fail("没有找到");
            }
        }


        public ResponseDto GetPostByForumId(int forumId)
        {
            var posts = baseRepository.GetPageAsync<DateTime>(x => x.ForumId == forumId, 1, 20, x => x.CreateTime);
            if (posts != null)
            {
                return ResponseDto.Success(posts);
            }
            else
            {
                return ResponseDto.Fail("没有找到");
            }
        }

        public ResponseDto GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }       
        public ResponseDto UpdatePost(PostDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdatePostAsync(PostDto dto)
        {
            throw new NotImplementedException();
        }
        private PostCache Mapping(PostDto postDto)
        {
            var postCache = new PostCache()
            {
                Id = postDto.Id,
                Context = postDto.Context,
                Subject = postDto.Subject,
                CreateTime = DateTime.UtcNow,
                ForumId=postDto.ForumId,
                CreateUserAvatar=postDto.CreateUserAvatar,
                CreateUserId=postDto.CreateUserId,
                CreateUserName=postDto.CreateUserName,
                CreateUserNickname=postDto.CreateUserNickname, 
                EndReplyTime=postDto.EndReplyTime,
                EndReplyUserId=postDto.EndReplyUserId,
                EndReplyUserNickname=postDto.EndReplyUserNickname,              
                CreateUerAvatarStream=postDto.CreateUserAvatarStream
            };           
            return postCache;
        }
    }
}
