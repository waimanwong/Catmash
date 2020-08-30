using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catmash.Domain;
using Catmash.Infrastructure;
using Catmash.Middlewares;
using Catmash.Middlewares.ErrorHandling;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Catmash
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

            services.AddScoped<IBattleService, BattleService>();
            services.AddScoped<IImageProvider, ImageProvider>();
            services.AddScoped<IBattleOutcomeRepository, BattleOutcomeRepository>();
            services.AddScoped<IValidator<BattleOutcomeDto>, BattleOutcomeDtoValidator>();
            services.AddScoped<IImageStatisticsProvider, ImageStatisticsProvider>();
            
            services.AddDbContext<CatmashDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
