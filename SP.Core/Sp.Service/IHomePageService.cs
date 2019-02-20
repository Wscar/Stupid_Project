using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
namespace Sp.Service
{
    public interface  IHomePageService
    {
        ResponseDto GetHomePageAreaAndForums();
        Task<ResponseDto> GetHomePageAreaAndForumsAsync();
        ResponseDto GetHomePagePosts();
        Task<ResponseDto> GetHomePageAsync();
    }
}
