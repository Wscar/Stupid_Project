using Sp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Models;
namespace Sp.Service
{
   public delegate object UserEvent(AppUser user);
   public interface IUserService
    {   
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        ResponseDto SignIn(string userName,string passWord);
        ResponseDto SignUp(string userName,string passWord,string nickName);
        ResponseDto UpdateUser();
        ResponseDto DeleteUser(int id );
        Task<ResponseDto> IsExistAsync(string userName);
        event UserEvent UserCreatedEvent;
        Task<ResponseDto> GetUserAvatarAsync(int userId);
        Task<ResponseDto> GetUserAvatarAsync(string userAvatrName);
        Task<ResponseDto> GetUserAsync(int userId);
    }
}
