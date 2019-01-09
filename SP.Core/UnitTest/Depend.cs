﻿using Microsoft.Extensions.DependencyInjection;
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
        private void AddDepend()
        {
            services = new ServiceCollection();
            services.AddScoped(mongoDbContext =>
            {
                return new SpMongoDbContext("mongodb://localhost:27017","sp");
            });
            services.AddDbContext<SPDbcontext>(options => options.UseMySql("server=localhost;uid=root;pwd=wqawd520;database=sp;Charset=utf8;port=3306"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImagerService>();
            services.AddScoped<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddScoped<IImageRepository, UserAvatarRepository>();
            services.AddScoped<IBaseRepository<UserRole>, RoleRepository>();
            serviceProvider = services.BuildServiceProvider();
        }
    }
}
