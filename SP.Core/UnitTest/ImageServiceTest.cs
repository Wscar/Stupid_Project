using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sp.Service;
using Microsoft.Extensions.DependencyInjection;
using SP.Repository;
using SP.Infrastructure;
using System.IO;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using System.Linq;
using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTest
{
  public  class ImageServiceTest
    {
        private readonly Depend depend;
        private readonly ITestOutputHelper outPut;
         public ImageServiceTest(ITestOutputHelper _outPut)
        {
            depend = new Depend();
            outPut = _outPut;
            
        }
        [Fact]
        public void  UpLoadeImageTest()
        {
            var imageRepository = depend.serviceProvider.GetRequiredService<IImageRepository>();
            var imageService = depend.serviceProvider.GetRequiredService<IImageService>();
            var mongonDbContext = depend.serviceProvider.GetRequiredService<SpMongoDbContext>();
            var fileStream=  File.OpenRead(@"C:\Users\夜莫白\Desktop\test.jpg");
            var bytes = new byte[fileStream.Length - 1];
            fileStream.Read(bytes, 0, bytes.Length);
            var fileName = "defaultAvatar";
             fileName= imageService.UpLoadeImage(bytes,fileName,"jpeg");
            var fliter = Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, fileName);
            using (var cursor = mongonDbContext.Bucket.Find(fliter))
            {
                if (cursor != null)
                {
                    var fileInfo = cursor.ToList().FirstOrDefault();
                    fileInfo.Filename.Should().Be(fileName);
                    Console.WriteLine($"找到了这个文件:{fileInfo.Filename}");
                }
                else
                {
                    cursor.Should().BeNull();
                    Console.WriteLine("没有找到这个文件");
                }
            }
        }
        [Fact]
        public void OutPutTest()
        {
            outPut.WriteLine("输出日志");
        }
    }
}
