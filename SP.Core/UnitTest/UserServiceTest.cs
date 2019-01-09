using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SP.Repository;
using SP.Models;
using Xunit;
using Sp.Service;
using Sp.Service.Dtos;

namespace UnitTest
{
   public class UserServiceTest
    {
        private readonly Depend depend;
        private readonly ITestOutputHelper outPut;
        public UserServiceTest (ITestOutputHelper _outPut)
        {
            depend = new Depend();
            outPut = _outPut;
        }
        [Fact]
        public void SignInTest()
        {
           
           
        }
        [Fact]
        public async void GetUserTest()
        {
            var userService = depend.serviceProvider.GetRequiredService<IUserService>();
            var result = await userService.GetUserAsync(1);
            var user = result.Data as UserDto;
            var roleCount = user.Roles.Count;
            outPut.WriteLine($"用户名是:{user.NickName}");
            outPut.WriteLine($"角色是：{user.Roles[0]}");
            Assert.Equal(1,roleCount);
        }
    }
}
