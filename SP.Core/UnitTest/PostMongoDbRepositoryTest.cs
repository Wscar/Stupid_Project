using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using System.Threading.Tasks;
using SP.Repository;
using Microsoft.Extensions.DependencyInjection;
using SP.Models.Cache;
namespace UnitTest
{
    public class PostMongoDbRepositoryTest
    {
        private readonly Depend depend;
        ITestOutputHelper outPut;
        private readonly PostMongoDbRepository postMongoDbRepository;
        public PostMongoDbRepositoryTest(ITestOutputHelper _outPut)
        {
            depend = new Depend();
            outPut = _outPut;
            postMongoDbRepository = depend.serviceProvider.GetRequiredService<PostMongoDbRepository>();
        }
        [Fact]
        public async  Task AddPostTest()
        {
            var postCache = new PostCache() {
                Id=17,
                ForumId=1,
                CreateUserId=1,
                CreateUserName= "夜莫白",
                CreateUserNickname= "夜莫白",
                CreateUserAvatar= "defaultAvatar",
                CreateTime=DateTime.Parse("2019-02-13 17:36:01"),
                Subject= "实在是扛不住压力了",
                Context= "哈哈哈哈哈哈",
                IsDelete=0,
                EndReplyTime=DateTime.Parse("2019-02-15 16:55:32"),
                EndReplyUserId=4,
                Comments=new List<CommentCache>
                {
                   new CommentCache
                   {
                       Id=3,
                       PostId=1,
                       Context="老弟怎么了啊，什么事啊",
                       CommentTime=DateTime.Parse("2019-02-15 15:27:00"),
                       CommentUserId=4,
                       CommentUserName="yemobai1",
                       CommentUserNickname="终点",
                       CommentUserAvatar=""
                   },new CommentCache
                   {
                       Id=3,
                       PostId=1,
                       Context="老弟怎么了啊，什么事啊",
                       CommentTime=DateTime.Parse("2019-02-15 16:55:32"),
                       CommentUserId=4,
                       CommentUserName="yemobai1",
                       CommentUserNickname="终点",
                       CommentUserAvatar=""
                   }
                }

            };

           await  postMongoDbRepository.AddAsync(postCache);
        }
    }
}
