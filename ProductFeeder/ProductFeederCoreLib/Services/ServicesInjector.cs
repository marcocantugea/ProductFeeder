using Microsoft.Extensions.DependencyInjection;
using ProductFeederCoreLib.Services;
using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Services
{
    public static class ServicesInjector
    {

        public static IServiceCollection InjectServices(IServiceCollection services)
        {
            services.AddScoped<IServices<SupplierServices>, SupplierServices>();
            services.AddScoped<IServices<BrandsServices>, BrandsServices>();
            services.AddScoped<IServices<ProductsServices>, ProductsServices>();
            return services;
        }

    }
}
