using Microsoft.Extensions.DependencyInjection;
using Sp.Service;
using SP.Infrastructure;
using SP.Models;
using SP.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace UnitTest
{
     public  class Depend
    {    
        public Depend()
        {
            this.AddDepend();
        }
        public IServiceCollection services;
        public ServiceProvider serviceProvider;
        private string sqlConnStr = "server=localhost;uid=root;pwd=wqawd520;database=sp;Charset=utf8;port=3306";
        private void AddDepend()
        {
            services = new ServiceCollection();
            services.AddScoped(mongoDbContext =>
            {
                return new SpMongoDbContext("mongodb://localhost:27017","sp");
            });
            services.AddDbContext<SPDbcontext>(options => options.UseMySql(sqlConnStr));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImagerService>();
            services.AddScoped<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddScoped<IImageRepository, UserAvatarRepository>();
            services.AddScoped<IBaseRepository<UserRole>, RoleRepository>();
            services.AddScoped<IBaseRepository<SpArea>, AreaRespository>();
            services.AddScoped<IBaseRepository<Forum>, ForumRepository>();
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IBaseRepository<Post>, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddSingleton<SqlMap>(x => { return new SqlMap(sqlConnStr); });
            services.AddScoped<PostMongoDbRepository>();
            serviceProvider = services.BuildServiceProvider();
        }
    }
}
