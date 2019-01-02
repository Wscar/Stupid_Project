using Sp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service
{
   public interface IUserService
    {
        ResponseDto SignIn(string userName,string passWord);
        ResponseDto SignUp();
        ResponseDto UpdateUser();
        ResponseDto DeleteUser();
        
    }
}
