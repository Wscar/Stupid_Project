using System;
using System.Collections.Generic;
using System.Text;
using Sp.Service.Dtos;
using SP.Models;
using Xunit;
using Sp.Service;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using SP.Models;
namespace UnitTest
{
   public class ForumServiceTest
    {   
        private readonly Depend depend;
        private readonly IForumService forumService;
         public ForumServiceTest()
        {
            depend = new Depend();
           forumService= depend.serviceProvider.GetRequiredService<IForumService>();
        }
        [Fact]
         public void CreateForumTest()
        {
            var forumDto = new ForumDto
            {
                Name = "程序员"+new Random().Next(0,100).ToString(),
                AreaId = 1,
                UserId = 1
            };
            var result= forumService?.CreateForum(forumDto);
            var forum = result.Data.Should().BeAssignableTo<Forum>().Subject;
            forum.Id.Should().BeGreaterOrEqualTo(0);
            forum.Name.Should().Be(forumDto.Name);
            forum.AreaId.Should().Be(forumDto.AreaId);
              
        }
        [Fact]
        public async void UpdateForumTest()
        {
            var forumDto = new ForumDto {
                Name = "javaScript",
                Id = 4
            };
            var result = await forumService.UpdateForumNameAsync(forumDto);
            var response=  result.Should().BeAssignableTo<ResponseDto>().Subject;
            response.Status.Should().Be(Status.Success);
            if (response.Status != Status.Fail&&response.Data!=null)
            {
                var forum = response.Data.Should().BeAssignableTo<Forum>().Subject;
                forum.Name.Should().Be(forumDto.Name);
            }                    
        }

        [Fact]
        public async void GetForumListTest()
        {
            var forumDto= new ForumDto {
                 AreaId=1
 
            };
            var result = await forumService.GetForumListAsync(1);
            var response = result.Should().BeAssignableTo<ResponseDto>().Subject;
            response.Status.Should().Be(Status.Success);
            var forums = response.Data.Should().BeAssignableTo<List<Forum>>().Subject;
            forums.Count.Should().BeGreaterThan(0);
        }
    }
}
