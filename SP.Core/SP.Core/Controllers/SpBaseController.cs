using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service.Dtos;
using SP.Models;
namespace SP.Core.Controllers
{ 
    public class SpBaseController : ControllerBase
    {
        protected  AppUser Identity
        {
            get
            {
                var user = new AppUser();
                user.Id = Convert.ToInt32(this.User.Claims.FirstOrDefault(x => x.Type == "sub").Value);
                //user.UserName = this.User.Claims.FirstOrDefault(x => x.Type == "userName").Value;
                user.NickName = this.User.Claims.FirstOrDefault(x => x.Type == "nickName").Value;
                user.Avatar = this.User.Claims.FirstOrDefault(x => x.Type == "avatar").Value;               
                return user;
            }
        }
        /// <summary>
        /// 返回响应
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected async Task<IActionResult> ResponseAsync(ResponseDto response)
        {
            if (response.Status == Status.Success)
            {
                return await Task.FromResult(Ok(response));
            }
            else
            {
                 return await Task.FromResult(BadRequest(response));
            }
        }
    }
}