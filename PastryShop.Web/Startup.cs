using System;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PastryShop.Core.Services;
using PastryShop.Core.Services.Impl;
using PastryShop.DAL;
using PastryShop.DAL.Interfaces;
using PastryShop.DAL.Repositories;
using PastryShop.Web.Areas.Identity;

namespace PastryShop.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Set the active provider via configuration
            var dbProvider = _configuration.GetValue("DBProvider", "SqlServer");
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            
            switch (dbProvider) {
                case "Sqlite":
                    
                    services.AddDbContext<PastryDbContext, PastrySqliteDBContext>(
                        options => options.UseSqlite(connectionString));
                    break;
                
                case "SqlServer":
                    services.AddDbContext<PastryDbContext, PastrySqlServerDBContext>(options =>
                        options.UseSqlServer(connectionString));
                    break;
                
                default:
                    throw new Exception($"Unsupported provider: {dbProvider}");
            }
            
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PastryDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<IPastryRepository, PastryRepository>();
            services.AddScoped<IPastryManagementService, PastryManagementService>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddBlazoredModal();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
