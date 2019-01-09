using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
using SP.Models;
using SP.Repository;
using System.Linq;
namespace Sp.Service
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<AppUser> userRepository;
        private readonly IBaseRepository<UserRole> roleReository;
        private readonly IImageService imageService;
        public UserService(IBaseRepository<AppUser> _userRepository, IImageService _imageService, IBaseRepository<UserRole> _roleReository)
        {
            this.userRepository = _userRepository;
            this.imageService = _imageService;
            this.roleReository = _roleReository;
        }
        public event UserEvent UserCreatedEvent;
        public ResponseDto DeleteUser(int id)
        {
            var user = this.userRepository.Get(x => x.Id == id);
            this.userRepository.Delete(user);
            return ResponseDto.Success(null);
        }
        public ResponseDto SignIn(string userName, string passWord)
        {   
            //必须返回用户的角色，用户密码和用户名不必返回，
           var user= userRepository.Get(x => x.UserName == userName && x.PassWord == passWord);
            var role = this.roleReository.GetList(x => x.UserId == user.Id);
            if (user != null)
            {
                var userDto = new UserDto { Id = user.Id, NickName = user.NickName, Avatar = user.Avatar };
                role.ToList().ForEach(x => userDto.Roles.Add(x.Type));
                return ResponseDto.Success(userDto);             
            }
            else
            {
                return ResponseDto.Fail("用户名和密码错误");
            }
        }
        public ResponseDto SignUp(string userName, string passWord, string nickName)
        {
            var newUser = new SP.Models.AppUser { UserName = userName, PassWord = passWord, RegisterTime = DateTime.Now,Avatar="defaultAvatar" };                              
            var user=  userRepository.Insert(newUser);
            var role = roleReository.Insert(new UserRole { UserId = user.Id, Type = "ordinary" });
            this.UserCreatedEvent?.Invoke(user);
            return new ResponseDto { Data = user };
        }
        public ResponseDto UpdateUser()
        {
            return null;
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
        public async Task<ResponseDto> GetUserAvatarAsync(string userAvatrName)
        {
             var imageBytes = await imageService.DownLoadImageAsync(userAvatrName);
             return ResponseDto.Success(imageBytes);
        }
        public Task<ResponseDto> GetUserAvatarAsync(int userId)
        {
            return null;
               
        }
        public async Task<ResponseDto> GetUserAsync(int userId)
        {
           var user=  await this.userRepository.GetAsync(x => x.Id == userId);
            var role = await this.roleReository.GetListAsync(x => x.Id == userId);           
           
            if (user != null)
            {                
                var userDto = new UserDto { Id = user.Id, NickName = user.NickName ,Avatar=user.Avatar};
                role.ToList().ForEach(x => userDto.Roles.Add(x.Type));
                return ResponseDto.Success(userDto);
            }
            else
            {
                return ResponseDto.Fail("没有找到这个用户");
            }
        }
        private  string AddDefaultUserAvatar()
        {
            return "默认图片";
        }

       
    }
}
