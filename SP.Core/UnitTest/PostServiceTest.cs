using System;
using System.Collections.Generic;
using System.Text;
using Sp.Service;
using Sp.Service.Dtos;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Xunit;
using System.Threading.Tasks;

namespace UnitTest
{
   public class PostServiceTest
    {
        private readonly Depend depend;
        private readonly IPostService postService;
        public PostServiceTest()
        {
            depend = new Depend();
           postService=  depend.serviceProvider.GetRequiredService<IPostService>();
        }

        [Fact]
        public  void  CreatePostTest()
        {
            var postDto = new PostDto()
            {
                ForumId = 3,
                Subject = "C# 中attribute是个怎么用法",
                Context = "如题",
                CreateUserId = 1
            };
            var  response=  postService?.CreatePost(postDto);
            response.Status.Should().Be(Status.Success);
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
    }
}
