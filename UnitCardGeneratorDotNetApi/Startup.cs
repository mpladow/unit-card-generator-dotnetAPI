using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnitCardGeneratorDotNetApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace UnitCardGeneratorDotNetApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private string _connectionString = null;
        private IWebHostEnvironment _appEnv = null;
        public Startup(IConfiguration configuration, IWebHostEnvironment appEnv)
        {
            Configuration = configuration;
            _appEnv = appEnv;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_appEnv.IsDevelopment())
            {
                var builder = new SqlConnectionStringBuilder(
                    Configuration.GetConnectionString("DefaultConnection"));
                builder.Password = Configuration["DbPassword"];
                _connectionString = builder.ConnectionString;

                services.AddDbContext<CardGeneratorContext>(options =>
                    options.UseSqlServer(_connectionString));

            }
            else
            {
                services.AddDbContext<CardGeneratorContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddCors(options =>
            {
                options.AddPolicy("allowedSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                        //builder.WithOrigins("https://unit-card-generator.web.app/", "http://localhost:3000/");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("allowedSpecificOrigins");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
