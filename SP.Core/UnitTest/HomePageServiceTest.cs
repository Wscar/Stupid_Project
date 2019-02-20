using Sp.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using FluentAssertions;
using Sp.Service.Dtos;
using System.Linq;
using Xunit;
using Sp.Service.ViewModel;
using SP.Models;
namespace UnitTest
{
   public class HomePageServiceTest
    {
        private readonly Depend depend;
        private IHomePageService homePageService;
        private readonly ITestOutputHelper outPut;
        public  HomePageServiceTest(ITestOutputHelper _outPut)
        {
            depend = new Depend();
            homePageService = depend.serviceProvider.GetRequiredService<IHomePageService>();
            outPut = _outPut;
        }
        [Fact]
        public  async  Task  GetHomeAreaTest()
        {
            var result=  await  homePageService.GetHomePageAreaAndForumsAsync();

            if (result.Status == Status.Success)
            {
                outPut.WriteLine("status是success");
                var data = result.Data.Should().BeAssignableTo<List<AreaVM>>().Subject;
                outPut.WriteLine("responseDto.data可以转换成List<AreaVM>");
                data.Count().Should().BeGreaterThan(0);
                outPut.WriteLine($"responseDto.data的数量大于0，且数量是{data.Count()}");
               
                foreach(var item in data)
                {
                    outPut.WriteLine("开始输出var item in data");
                    outPut.WriteLine($"areaId是:{item.Id}");
                    outPut.WriteLine($"areaName是：{item.Name}");
                    outPut.WriteLine("开始输出相应的板块");
                    item.ForumVMs.Should().NotBeNull();
                    outPut.WriteLine("item 里面ForumVms不为空");
                    item.ForumVMs.Count.Should().BeGreaterOrEqualTo(0);
                    outPut.WriteLine("item 里面ForumVms集合里面的数量大于=0");
                    outPut.WriteLine("开始输出item 里面ForumVms集合里面的元素"); 
                    foreach(var forum in item.ForumVMs)
                    {
                        outPut.WriteLine($"forumId是:{forum.Id}");
                        outPut.WriteLine($"forumName是:{forum.Name}");                     
                    }
                }
            }
            else
            {
                outPut.WriteLine("status是fail");
                outPut.WriteLine($"失败原因:{result.Msg}");
            }
           
           
        }
        [Fact]
        public async Task GetHomePostTest()
        {
            var result = await homePageService.GetHomePageAsync();
            result.Status.Should().Be(Status.Success);
            outPut.WriteLine("GetHomePostTest方法中,result.Status是success");
            var posts = result.Data.Should().BeAssignableTo<List<Post>>().Subject;
            posts.Count.Should().BeGreaterThan(0);
            outPut.WriteLine("GetHomePostTest方法中,data里面的元素超过0");
        }
    }
}
