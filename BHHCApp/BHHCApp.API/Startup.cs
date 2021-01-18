using BHHCApp.Core;
using BHHCApp.Core.Services;
using BHHCApp.Infrastructure;
using BHHCApp.Infrastructure.Data;
using BHHCApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BHHCApp.API
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
            services.AddControllers();

            //injections of services 
            var connectionString = @"source=localhost;database=bhhc;Integrated Security=SSPI;persist security info=True;"" providerName = ""System.Data.SqlClient";
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>((serviceProvider, options) =>
                    options.UseSqlServer(connectionString)
                    .UseInternalServiceProvider(serviceProvider));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReasonService, ReasonService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
