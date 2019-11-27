using Kledex.Bus.RabbitMQ.Extensions;
using Kledex.Caching.Memory;
using Kledex.Extensions;
using Kledex.Store.Cosmos.Sql;
using Kledex.Store.Cosmos.Sql.Extensions;
using Kledex.UI.Extensions;
using Kledex.Validation.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyProject.Domain.Handlers.Products;
using MyProject.Domain.Models.Products.Commands;
using MyProject.Domain.Validators.Products;
using MyProject.Reporting.Data;
using MyProject.Reporting.Handlers;

namespace MyProject.Web
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
            services.AddRazorPages();

            services.AddDbContext<ReportingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ReadModel")));

            services
                .AddKledex(typeof(CreateProductHandler), typeof(CreateProductValidator), typeof(ProductCreatedHandler))
                .AddCosmosDbSqlProvider(Configuration)
                .AddRabbitMQProvider()
                .AddFluentValidationProvider()
                .AddMemoryCacheProvider()
                .AddUI();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ReportingDbContext reportingDbContext, IOptions<DomainDbOptions> settings)
        {
            reportingDbContext.Database.EnsureCreated();
            app.UseKledex().EnsureCosmosDbSqlDbCreated(settings);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
