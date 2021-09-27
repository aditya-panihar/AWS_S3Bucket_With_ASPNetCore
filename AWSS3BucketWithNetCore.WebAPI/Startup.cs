using Amazon.S3;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Repositories;
using AWSS3BucketWithNetCore.Domain.Services.Interfaces.Services;
using AWSS3BucketWithNetCore.Domain.Services.Services;
using AWSS3BucketWithNetCore.Infrastructure.Http.Clients.AWS.S3;
using AWSS3BucketWithNetCore.Infrastructure.Http.Clients.AWS.S3.Models;
using AWSS3BucketWithNetCore.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSS3BucketWithNetCore.WebAPI
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<AWSS3Bucket>(Configuration.GetSection("AWSS3Bucket"));
            services.AddAWSService<IAmazonS3>();
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddTransient<ICatalogRepository, CatalogRepository>();
            services.AddTransient<FilesRepositoryClient>();
            services.AddTransient<BucketsRepositoryClient>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Catalog service API",
                    Version = "v1",
                    Description = "Sample service for Learner"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog services");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
