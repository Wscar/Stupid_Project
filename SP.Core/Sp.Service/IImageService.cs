using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sp.Service.Dtos;
namespace Sp.Service
{
   public interface IImageService
    {
        string UpLoadeImage(byte[] source, string fileName, string fileType);
        Task<string> UpLoadImageAsync(byte[] source, string fileName,string fileType);
        Task<byte[]> DownLoadImageAsync(string fileName);
        byte[] DownLoadImage(string fileName);
       
    }
}
