using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using LocalizationSample.Data;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using LocalizationSample.Localizers;

namespace LocalizationSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Helpers.EnvironmentHelper.DockerArguments != null && Helpers.EnvironmentHelper.DockerArguments.Count() > 0)
            {

                services.AddDbContext<LocalizationDBContext>(options =>
                    options.UseNpgsql(Configuration["Data:StoreDbContext:ConnectionString"]));
            }
            else
            {
                services.AddDbContext<LocalizationDBContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultDbContext:ConnectionString"]));
            }

            services.AddSingleton<IStringLocalizerFactory, EFStringLocalizerFactory>();
            // Add framework services.
            services.AddMvc()
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("vi-VN"),
                new CultureInfo("fr-FR"),
                new CultureInfo("pt-BR"),
                new CultureInfo("es-ES"),
                new CultureInfo("jp-JP"),
                new CultureInfo("zh"),
                new CultureInfo("zh-CN"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("vi-VN", "vi-VN"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
