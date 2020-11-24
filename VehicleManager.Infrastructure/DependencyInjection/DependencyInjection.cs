using Microsoft.Extensions.DependencyInjection;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infrastructure.Repositories;

namespace VehicleManager.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
