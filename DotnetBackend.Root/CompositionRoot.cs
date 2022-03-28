using DotnetBackend.Data;
using DotnetBackend.Data.Repositories;
using DotnetBackend.Data.Repositories.Implementations;
using DotnetBackend.Service;
using DotnetBackend.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBackend.Root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services, IConfiguration config)
        {
            // inject dependencies here
            // db context 
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.EnableSensitiveDataLogging();
                options.UseLazyLoadingProxies()
            .UseSqlServer(config.GetConnectionString("DefaultConnection")).ConfigureWarnings((config) =>
                config.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)
            );
            });

            // repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMetalPriceService, MetalPriceService>();

        }
    }
}
