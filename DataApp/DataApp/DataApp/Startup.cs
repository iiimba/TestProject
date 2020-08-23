using DataApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connectionString = this.Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            });
            var customerConnectionString = this.Configuration["ConnectionStrings:CustomerConnection"];
            services.AddDbContext<CustomerContext>(options =>
            {
                options.UseSqlServer(customerConnectionString);
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
