using AutoMapper;
using App.src.commands;
using App.src.commands.price;
using App.src.domains;
using App.src.resource.mysql;
using App.src.resource.mysql.models;
using App.src.resource.mysql.repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace App
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

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IReadPriceCsv<PriceDtc>, ReadPriceCsv>();

            services.AddScoped<ISaveCsvPrice<PriceDtc>, SaveCsvPrice>();

            RegisterRepositories(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ImportDbContext>(_ => new ImportDbContext(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPriceRepository<Price>, PriceRepository>();
            services.AddScoped<IBaseRepository<Price>, PriceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImportCsv API");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
