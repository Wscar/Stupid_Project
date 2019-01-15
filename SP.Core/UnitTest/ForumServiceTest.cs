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
                Name = "程序员",
                AreaId = 1,
                UserId = 1
            };
            var result= forumService?.CreateForum(forumDto);
            var forum = result.Data.Should().BeAssignableTo<Forum>().Subject;
            forum.Id.Should().BeGreaterOrEqualTo(0);
            forum.Name.Should().Be(forumDto.Name);
            forum.AreaId.Should().Be(forumDto.AreaId);
              
        }
    }
}
