using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ninject.Modules;
using ROIMethod.Controllers;
using ROIMethod.DataConnectionTemplates.MSQLTemplate;
using ROIMethod.DataInfrastructure.DataUtils;
using ROIMethod.DataInfrastructure.DataUtils.Repositories._Interfaces;
using ROIMethod.WebAPI.Core.CaseServices;
using ROIMethod.WebAPI.Core.CaseServices.Interface;
using System.IO;

namespace ROIMethod
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            CRoot = hostEnvironment.WebRootPath;
        }

        public IConfiguration Configuration { get; }
        public string CRoot { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Dependencies
            services.AddTransient<IConfigBQConnection, ConfigBQConnection>(serviceProvider =>
            {

                var connectionString = Path.Combine(CRoot, "bq-auth.json");
                return new ConfigBQConnection(connectionString);
            });
            services.AddTransient<IBigQueryService, BigQueryService>();
            services.AddTransient<IBQStatisticService, DataBQService>();
            services.AddTransient<IStatisticService, StatisticService>();
            services.AddTransient<IAppDataConnection,DataContext>(serviceProvider =>
            {
                var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                return new DataContext(connectionString);
            });
            #endregion

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
