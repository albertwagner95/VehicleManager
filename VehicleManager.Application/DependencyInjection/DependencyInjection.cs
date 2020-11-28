using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;

namespace VehicleManager.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
