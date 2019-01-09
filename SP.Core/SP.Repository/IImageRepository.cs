using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SP.Repository
{
   public interface IImageRepository
    {    
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="imageBytes">图片流</param>
        /// <param name="fileName">文件名,不传文件名的话，回随机生成一个Guid文件名</param>
        /// <returns>返回文件名</returns>
         string  UpLoadImage(byte[] imageBytes,string fileName=null,string fileType=null);
        /// <summary>
        ///  更新图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="imageBytes">图片对象流</param>
        /// <returns>返回文件名</returns>
         string  UpdateImage(string fileName, byte[] imageBytes);

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
         byte[] DownLoadImage(string fileName);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
         bool DeltetImage(string fileName);


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="imageBytes">图片流</param>
        /// <param name="fileName">文件名,不传文件名的话，回随机生成一个Guid文件名</param>
        /// <returns>返回文件名</returns>
        Task<string> UpLoadImageAsync(byte[] imageBytes, string fileName = null,string fileType=null);
        /// <summary>
        ///  更新图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="imageBytes">图片对象流</param>
        /// <returns>返回文件名</returns>
        Task<string> UpdateImageAsync(string fileName, byte[] imageBytes);

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>字节数组</returns>
        Task<byte[]> DownLoadImageAsync(string fileName);

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        Task<bool> DeltetImageAsync(string fileName);
    }
}
