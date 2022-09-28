using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Extensions.ServiceRegistrations
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<OrderingDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("OrderDbConnectionString")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
