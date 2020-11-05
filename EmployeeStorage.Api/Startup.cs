using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EmployeeStorage.DataAccess.Configuration;
using EmployeeStorage.Service.Infrastructure;
using EmployeeStorage.Service.Services;
using EmployeeStorage.DataAccess.Interfaces;
using EmployeeStorage.DataAccess.Repositories;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace EmployeeStorage.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors();
            services.AddDbContext<EmployeeStorageContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeStorageDb")));
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../ClientApp";
            });
        }
    }
}
