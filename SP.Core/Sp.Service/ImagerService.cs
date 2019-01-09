using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Repository;
namespace Sp.Service
{   
    public class ImagerService : IImageService
    {   
        private readonly IImageRepository imageRepository;
        public ImagerService(IImageRepository _imageRepository)
        {
            this.imageRepository = _imageRepository;
        }

        public byte[] DownLoadImage(string fileName)
        {
           return imageRepository.DownLoadImage(fileName);
        }

        public Task<byte[]> DownLoadImageAsync(string fileName)
        {
            return imageRepository.DownLoadImageAsync(fileName);
        }

        public string UpLoadeImage(byte[] source, string fileName, string fileType)
        {
           return this.imageRepository.UpLoadImage(source, fileName);
             
        }

        public Task<string> UpLoadImageAsync(byte[] source, string fileName, string fileType)
        {
           return this.imageRepository.UpLoadImageAsync(source, fileName);
        }
    }
}
