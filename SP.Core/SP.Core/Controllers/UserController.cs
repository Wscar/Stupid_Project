using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
using SP.Core.viewModel;
namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
    }
}