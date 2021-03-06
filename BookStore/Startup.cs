using BookStore.Models.DBModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookStore.DataAccessLayer.Interface;
using BookStore.DataAccessLayer.Implementation;
using BookStore.BussinessLayer.Implementation;
using BookStore.BussinessLayer.Interface;
using BookStore.DomainModels.Models.Constants;
using BookStore.DomainModels.Models.Configurations;
using Microsoft.Extensions.Options;
using BookStore.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BookStore
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/User/LogIn";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/User/AccessDenied";
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserType.Admin, policy => policy.Requirements.Add(new PermissionRequirement(UserType.Admin)));
                options.AddPolicy(UserType.User, policy => policy.Requirements.Add(new PermissionRequirement(UserType.User)));
            });

            services.AddDbContext<BookstoreDBContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionString));
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.SetupDependancy(Configuration);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCorsMiddleware();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=BookStore}/{action=Index}/{id?}");
            });
        }
    }
}
