using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sp.Authentication.Service;
namespace Sp.Authentication
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
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
               .AddInMemoryApiResources(IdentityServerConfig.GetApiResource())
               .AddInMemoryClients(IdentityServerConfig.GetClients())
               .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
               .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
               .AddProfileService<ProfileService>()

                .AddCorsPolicyService<CorsPolicyService>();
               
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication()
                .AddIdentityServerAuthentication("bearer", options =>
                {
                    options.ApiSecret = "yemobai";
                    options.RequireHttpsMetadata = false;


                })
                ;

            services.AddHttpClient();
            services.AddScoped<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(buider =>
            {
                buider.WithOrigins("http://localhost:8080")
                .AllowAnyHeader();
            });
            app.UseIdentityServer();
           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
