using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SP.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sp.Service;
using SP.Repository;
using SP.Models;
using IdentityServer4;
using SP.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SP.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityServer()
            //     .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(IdentityServerConfig.GetApiResource())
            //    .AddInMemoryClients(IdentityServerConfig.GetClients())
            //    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            services.AddDbContext<SPDbcontext>(options => options.UseMySql(Configuration.GetConnectionString("MySql")));
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //services.AddAuthentication()              
            //     .AddIdentityServerAuthentication(JwtBearerDefaults.AuthenticationScheme,options =>
            //     {
            //         options.Authority = "http://localhost:5000";
            //         options.ApiName = "sp_api";
            //         options.ApiSecret = "yemobai";
            //         options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
            //         options.RequireHttpsMetadata = false;
            //     });
           
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Audience = "sp_api";
                    options.Authority = "http://localhost:5001";
                    options.SaveToken = true;
                    
                })         
                ;
            services.AddAuthorization(options =>
            {
                options.AddPolicy("allUser", policy => policy.RequireClaim("role","ordinary","admin"));
                options.AddPolicy("admin", policy => policy.RequireClaim("role", "admin"));
                options.AddPolicy("ordinary", policy => policy.RequireClaim("role", "ordinary"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped(mongoDbContext =>
            {
                return new SpMongoDbContext(this.Configuration.GetConnectionString("MongoDb"), this.Configuration.GetConnectionString("MongoDbDatabaseName"));
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImagerService>();
            services.AddScoped<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddScoped<IBaseRepository<UserRole>, RoleRepository>();
            services.AddScoped<IImageRepository, UserAvatarRepository>();
            services.AddScoped<IBaseRepository<SpArea>, AreaRespository>();
            services.AddScoped<IBaseRepository<Forum>, ForumRepository>();
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IBaseRepository<Post>, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddSingleton<SqlMap>(x => { return new SqlMap(Configuration.GetConnectionString("MySql") ); });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8080")
               .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
            app.UseAuthentication();
           // app.UseIdentityServer();
            app.UseMvc();
           
           
        }
    }
}
