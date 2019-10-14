using eMentor.Common.Models;
using eMentor.DBContext;
using eMentor.DBContext.Services;
using eMentor.DBContext.Services.impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Reflection;

namespace eMentorUserServices
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

        }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddDbContext<EMentorContext>(options =>
            {
                options.UseMySql(_configuration.GetConnectionString("DefaultConnection"));
            });

            var settingsSection = _configuration.GetSection("ConnectionStrings");
            var identitySettings = settingsSection.Get<IdentitySettings>();

            services.AddTransient<IAppSettingService>(s => new AppSettingService(identitySettings));

            services.AddScoped<DbContextFactory>();

            services.AddLogging();
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
                app.UseHsts();
            }
            app.UseCors(b => b.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin()
             .AllowCredentials()
            );

            app.UseSpaStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
