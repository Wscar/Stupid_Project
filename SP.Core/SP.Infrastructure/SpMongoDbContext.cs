using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
namespace SP.Infrastructure
{
   public class SpMongoDbContext
    {   
        public IMongoDatabase DataBase { get; set; }
        public GridFSBucket Bucket { get; set; }
        private string ConnStr { get; set; }
        private string Name { get; set; }
        public SpMongoDbContext(string connStr,string DataBaseName)
        {
            this.ConnStr = connStr;
            this.Name = DataBaseName;
            this.Initialize();
        }
        private void Initialize()
        {
            var client = new MongoClient(this.ConnStr);
            if (client != null)
            {
                DataBase = client.GetDatabase(this.Name);
                this.Bucket = new GridFSBucket(DataBase);
            }
        }
    }
}
