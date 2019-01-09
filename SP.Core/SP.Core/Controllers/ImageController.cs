using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sp.Service;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        public ImageController(IImageService _imageService)
        {
            this.imageService = _imageService;
           
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]List<IFormFile> files)
        {
            foreach(var formFile in files)
            { 
                using(var stream= formFile.OpenReadStream())
                { byte[] fileByte = new byte[stream.Length - 1];
                  var count= await  stream.ReadAsync(fileByte, 0, fileByte.Length);
                    var  index= formFile.FileName.LastIndexOf(".");
                    var fileType = formFile.FileName.Substring(index);
                   await this.imageService.UpLoadImageAsync(fileByte,formFile.FileName,fileType);
                }
            }
            // 立即更新是由那些用户上传了图片
            return Ok();
        }
        [HttpGet]
        [Route("{fileName}")]
        public async Task<IActionResult> DownLoadImage(string fileName)
        {
            var imageBytes= await this.imageService.DownLoadImageAsync(fileName);
            var index = fileName.LastIndexOf(".");
            var fileType = fileName.Substring(index+1);
            return new FileContentResult(imageBytes, "image/" + fileType);
        }
        
    }
}