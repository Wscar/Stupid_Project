using System;
using System.Collections.Generic;
using System.Text;
using Sp.Service;
using Sp.Service.Dtos;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Xunit;
using System.Threading.Tasks;
using SP.Models;
using SP.Models.Cache;
namespace UnitTest
{
    public class PostServiceTest
    {
        private readonly Depend depend;
        private readonly IPostService postService;
        private readonly ICacheService<PostCache> cacheService;
        public PostServiceTest()
        {
            depend = new Depend();
            postService = depend.serviceProvider.GetRequiredService<IPostService>();
            cacheService = depend.serviceProvider.GetRequiredService<ICacheService<PostCache>>();
        }

        [Fact]
        public void CreatePostTest()
        {
            var postDto = new PostDto()
            {
                ForumId = 3,
                Subject = "如何看待asp.net core3.0的发布",
                Context = "如何看待.net core 3.0开始支持winfrom,wpf",
                CreateUserId = 1,
                CreateUserName = "夜莫白",
                CreateUserNickname = "夜莫白",
                CreateUserAvatar = "defaultAvatar",
            };
            var response = postService?.CreatePost(postDto);
            response.Status.Should().Be(Status.Success);
            var data = response.Data.Should().BeAssignableTo<Post>().Subject;
            var postCache = cacheService.GetCache(new PostCache { Id = data.Id });
            postCache.Subject.Should().Be(postDto.Subject);
        }

        [Fact]
        public async Task CreatePostAsyncTest()
        {
            var postDto = new PostDto()
            {
                ForumId = 3,
                Subject = "C# 中attribute是个怎么用法",
                Context = "如题",
                CreateUserId = 1
            };
            var response = await postService?.CreatePostAsync(postDto);
            response.Status.Should().Be(Status.Success);
        }
        [Fact]
        public async Task GetPagePostAsyncTest()
        {
            var responseDto = await postService?.GetPagePostAsync(3, 1, 20);
            
            responseDto.Status.Should().Be(Status.Success);
            var data = responseDto.Data.Should().BeAssignableTo<List<PostCache>>().Subject;
            data.Count.Should().BeGreaterThan(0);
        }
    }
}
