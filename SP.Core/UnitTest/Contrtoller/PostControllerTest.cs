using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using SP.Core.Controllers;
using SP.Core.viewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Sp.Service;
using Sp.Service.Dtos;
namespace UnitTest
{
    public class PostControllerTest
    {

        private readonly ITestOutputHelper testOutputHelper;
        private readonly Depend depend;
        public PostControllerTest(ITestOutputHelper _testOutputHelper)
        {
            testOutputHelper = _testOutputHelper;
            depend = new Depend();
        }
        private PostController GetController()
        {
            var mapper = depend.serviceProvider.GetRequiredService<IMapper>();
            var postService = depend.serviceProvider.GetRequiredService<IPostService>();
            var postController = new PostController(postService, mapper);
            return postController;
        }
        [Fact]
        public async Task Post_ReturnScucceCode_WithExpectedParamerters()
        {
            var controller = GetController();
            var viewModel = new PostViewModel()
            {
                ForumId = 3,
                Subject = "2019-3-19，我很后悔我为什么要离开杭州",
                Context = "离开杭州我感到非常的后悔",
                CreateUserId = 1,
                CreateUserName = "夜莫白",
                CreateUserNickname = "夜莫白",
                CreateUserAvatar = "defaultAvatar",
            };
            var response = await controller.Create(viewModel);
            var result = response.Should().BeAssignableTo<OkObjectResult>().Subject;
            var responseDto = result.Value.Should().BeAssignableTo<ResponseDto>().Subject;
            responseDto.Status.Should().Be(Status.Success);
        }
    }
}
