using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Tests
{
    public static class MapperConfig
    {
        private static MapperConfiguration Configuration()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            return config;
        }
        public static IMapper Mapper()
        {
            var configuration = Configuration();
            var mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}
