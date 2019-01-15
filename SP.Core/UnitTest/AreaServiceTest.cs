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
namespace UnitTest
{
   public  class AreaServiceTest
    {
        private readonly Depend depend;
        private IAreaService areaService;
        public AreaServiceTest()
        {
            depend = new Depend();
            areaService = depend.serviceProvider.GetRequiredService<IAreaService>();
           
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
       
    }
}
