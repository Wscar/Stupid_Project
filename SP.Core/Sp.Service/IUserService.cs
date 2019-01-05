using Sp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sp.Service
{
   public interface IUserService
    {
        ResponseDto SignIn(string userName,string passWord);
        ResponseDto SignUp(string userName,string passWord,string nickName);
        ResponseDto UpdateUser();
        ResponseDto DeleteUser();
        Task<ResponseDto> IsExistAsync(string userName);      
        
    }
}
