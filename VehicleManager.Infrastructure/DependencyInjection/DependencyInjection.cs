using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infrastructure.Repositories;

namespace VehicleManager.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}
