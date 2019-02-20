using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SP.Core.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Sp.Service;
using Xunit;
using Sp.Service.Dtos;
using FluentAssertions;
using SP.Models;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTest
{
   public  class AreaServiceTest
    {
        private readonly Depend depend;
        private IAreaService areaService;
        private readonly ITestOutputHelper outPut;
        public AreaServiceTest(ITestOutputHelper _outPut)
        {
            depend = new Depend();
            areaService = depend.serviceProvider.GetRequiredService<IAreaService>();
            outPut = _outPut;
           
        }
         [Fact]
         public void CreatAreaTest()
        {
            var areaDto = new AreaDto
            {
                Name = "技术" + "\\" + Guid.NewGuid().ToString(),
                CreateUserId = 1

            };
            var result= areaService.CreateArea(areaDto);
           var  area=  result.Data.Should().BeAssignableTo<SpArea>().Subject;
            area.Name.Should().Be(areaDto.Name);
            area.Id.Should().BeGreaterThan(0);
            area.CreateUserId.Should().Be(areaDto.CreateUserId);
        }
        [Fact]
        public  async  Task GetAllAreasTest()
        {
            var result = await areaService.GetAreasAsync();
            result.Status.Should().Be(Status.Success);
            result.Data.Should().NotBeNull();
            var areas= result.Data.Should().BeAssignableTo<List<SpArea>>().Subject;
            areas.Count.Should().BeGreaterThan(0);
            foreach(var item in areas)
            {
                outPut.WriteLine(item.Name);
            }
        }
       
    }
}
