using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
using SP.Core.viewModel;
namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SpBaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }
         [Route("signup")]
         [HttpPost]
         public  IActionResult SignUp(SignUpVM signUp)
         {
            
           var resutl= userService.SignUp( signUp.UserName,signUp.PassWord,signUp.Nickname);
            return Ok(resutl);
         }
        [Route("signin")]
        [HttpPost]
         public IActionResult SignIn([FromForm]string userName,[FromForm]string password)
         {
            var result = userService.SignIn(userName,password);
            return Ok(result);
         }
        [Authorize(Policy = "admin")]
        [Route("{id}")]
         [HttpDelete]
         public IActionResult DeleteUser(int id)
        {
            var result= userService.DeleteUser(id);
            return Ok(result);
        }
        [HttpGet]
        [Authorize(Policy = "allUser")]
        public async Task<IActionResult> GetUser()
        {
           var user= await this.userService.GetUserAsync(this.Identity.Id);
            return Ok(user);
        }
    }
}