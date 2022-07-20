using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using SQICS_Api.Logger;
using SQICS_Api.Logger.Interface;
using SQICS_Api.Middleware;
using SQICS_Api.Model.Context;
using SQICS_Api.Service;
using SQICS_Api.Service.Interface;
using SQICS_Api.Service.Login;
using SQICS_Api.Service.Plan;
using SQICS_Api.UOW;
using System;
using System.IO;

namespace SQICS_Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<SQICSContext>(o => o.UseSqlServer(Configuration.GetConnectionString("SQICSConnection")));
            services.AddSingleton<DapperContext>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SQICS_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SQICS_Api v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
