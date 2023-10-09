using EasyGroceries.Product.Application.Contracts.Persistence;
using EasyGroceries.Product.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGroceries.Product.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<LeaveManagementDbContext>(options =>
            //   options.UseSqlServer(
            //       configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped<IProductInfoRepository, ProductInfoRepository>();

            return services;
        }
    }
}
