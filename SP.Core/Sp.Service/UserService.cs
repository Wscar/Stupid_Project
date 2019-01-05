using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Models;
using SP.Repository;

namespace Sp.Service
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<AppUser> userRepository;
        public UserService(IBaseRepository<AppUser> _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public ResponseDto DeleteUser()
        {
            throw new NotImplementedException();
        }

        public ResponseDto SignIn(string userName, string passWord)
        {
           var user= userRepository.Get(x => x.UserName == userName && x.PassWord == passWord);
            if (user != null)
            {
                return ResponseDto.Success(user);
            }
            else
            {
                return ResponseDto.Fail("用户名和密码错误");
            }
        }

        public ResponseDto SignUp(string userName, string passWord, string nickName)
        {
            var user=  userRepository.Insert(new SP.Models.AppUser { UserName = userName, PassWord = passWord, RegisterTime = DateTime.Now });
            return new ResponseDto { Data = user };
        }

        public ResponseDto UpdateUser()
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDto> IsExistAsync(string userName)
        {
            var result = await userRepository.GetAsync(x => x.UserName == userName);
            if (result != null)
            {
                return ResponseDto.Fail("用户名重复,请更换用户名");
            }
            else
            {
                return ResponseDto.Success(null);
            }           
        }
    }
}
