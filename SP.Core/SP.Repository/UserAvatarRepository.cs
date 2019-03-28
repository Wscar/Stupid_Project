using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using SP.Infrastructure;
using System.Linq;
using MongoDB.Bson;

namespace SP.Repository
{
    public class UserAvatarRepository : IImageRepository
    {
        private readonly SpMongoDbContext dbContext;
        public UserAvatarRepository(SpMongoDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public string UpLoadImage(byte[] imageBytes, string fileName = null,string fileType=null)
        {
            var newFileName = "";
            if(fileName == null&&fileType==null)
            {
                newFileName = Guid.NewGuid().ToString()+fileType;
            }
            else
            {
                newFileName = fileName;
            }
            dbContext.Bucket.UploadFromBytes(newFileName, imageBytes);
            return newFileName;
        }
        public string UpdateImage(string fileName, byte[] imageBytes)
        {    
        
            dbContext.Bucket.Delete(fileName);
            dbContext.Bucket.UploadFromBytes(fileName, imageBytes);
            return fileName;
        }
        public Task<string> UpLoadImageAsync(byte[] imageBytes, string fileName = null,string fileType=null)
        {
            var newFileName = "";
            if (fileName == null&&fileType==null)
            {
                newFileName = Guid.NewGuid().ToString()+fileType;
            }
            else
            {
                newFileName = fileName;
            }
            dbContext.Bucket.UploadFromBytesAsync(newFileName, imageBytes);
            return Task.FromResult(fileName);
        }
       public  Task<string> UpdateImageAsync(string fileName, byte[] imageBytes)
        {
            dbContext.Bucket.Delete(fileName);
            dbContext.Bucket.UploadFromBytes(fileName, imageBytes);
            return Task.FromResult(fileName);
        }

        public byte[] DownLoadImage(string fileName)
        {
           
            byte[] imageBytes;
            var id=  this.FindImage(fileName);
            imageBytes= dbContext.Bucket.DownloadAsBytes(id);
            return imageBytes;
        }

        public bool DeltetImage(string fileName)
        {
            var id = this.FindImage(fileName);
             dbContext.Bucket.Delete(id);
            //此处代码需要考虑是否删除成功。
            return true;
        }

        public Task<byte[]> DownLoadImageAsync(string fileName)
        {
           
            var id = this.FindImage(fileName);
            var imageBytes = dbContext.Bucket.DownloadAsBytesAsync(id);         
            return imageBytes;
        }

        public Task<bool> DeltetImageAsync(string fileName)
        {
            throw new NotImplementedException();
        }
        private ObjectId  FindImage(string fileName)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, fileName);
            var sort = Builders<GridFSFileInfo>.Sort.Descending(x => x.UploadDateTime);          
            var options = new GridFSFindOptions
            {
                Sort = sort,
                Limit = 1
            };
            //现在到这个文件的objectId,
           
            var cursor = dbContext.Bucket.Find(filter, options);
            using (cursor)
            {
                if (cursor == null)
                {
                    throw new ArgumentNullException($"mongoDb找不到这图片,文件名:{fileName}");
                }
                else
                {
                    var fileInfo = cursor.SingleOrDefault();
                    ObjectId id = fileInfo.Id;
                    return id;
                }
            }
           
        }
        private async Task<ObjectId> FindImageAsync(string fileName)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, fileName);
            var sort = Builders<GridFSFileInfo>.Sort.Descending(x => x.UploadDateTime);         
            var options = new GridFSFindOptions
            {
                Sort = sort,
                Limit = 1
            };
            //现在到这个文件的objectId,
            var cursor = await dbContext.Bucket.FindAsync(filter, options);
            using (cursor)
            {
                if (cursor == null)
                {
                    throw new ArgumentNullException($"mongoDb找不到这图片,文件名:{fileName}");
                }
                else
                {
                    var fileInfo = cursor.SingleOrDefault();
                    ObjectId id = fileInfo.Id;
                    return id;
                }
            }
        }
    }
}
