using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOS_L1_201945D.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FOS_L1_201945D.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FOS_L1_201945D.Configuration;
using Microsoft.Extensions.Logging;

namespace FOS_L1_201945D
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FruitsOrderDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<FOUserDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LoginConnection"));
            });

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptionHandler("/Errors");
            app.UseStatusCodePagesWithReExecute("/Errors/HttpError/{0}");

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Orders}/{action=orderHistory}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    RoleManager<IdentityRole> rm = services.GetRequiredService<RoleManager<IdentityRole>>();
                    UserManager<ApplicationUser> um = services.GetRequiredService<UserManager<ApplicationUser>>();
                    UserRoleSeed.Seed(rm, um);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Startup>>();
                    logger.LogError(ex, "An error occcured during data seeding");
                }
            }


        }
    }
}
