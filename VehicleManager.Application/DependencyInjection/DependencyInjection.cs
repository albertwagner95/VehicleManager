using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.Services;

namespace VehicleManager.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
