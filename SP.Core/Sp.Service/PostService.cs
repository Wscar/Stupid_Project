﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Models;
using SP.Repository;
namespace Sp.Service
{
    public class PostService : IPostService
    {
        private readonly IBaseRepository<Post> baseRepository;
        public PostService(IBaseRepository<Post> _baseRepository)
        {
            baseRepository = _baseRepository;
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
                return ResponseDto.Success(null);
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
                Context = dto.Context      
            };
            var post = await baseRepository.InsertAsync(newPost);
            if (post != null)
            {
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

        public ResponseDto UpdatePost(PostDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdatePostAsync(PostDto dto)
        {
            throw new NotImplementedException();
        }
    }
}