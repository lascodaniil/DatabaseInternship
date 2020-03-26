using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServerPart.API.EFDbContext;
using ServerPart.API.Repositories.Interfaces;

namespace ServerPart.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(option =>
            //    {
            //        option.Authority = "http://localhost:5000";
            //        option.RequireHttpsMetadata = false;
            //        option.ApiName = "ServerPart.API";
            //    });

            //services.AddAuthentication("Bearer").AddJwtBearer("Bearer",
            //    option =>
            //    {
            //        option.Authority = "http://localhost:5000";
            //        option.RequireHttpsMetadata = false;
            //        option.Audience = "ServerPart.API";
            //    });

            services.AddMvc();
           // services.AddDbContext<FLCenterDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FLCenterDbContext")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Register}/{action=Add}/{id?}");
            });

        }
    }
}
