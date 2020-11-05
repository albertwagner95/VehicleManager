using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleTypeVm : IMapFrom<VehicleType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleType, VehicleTypeVm>();
        }
    }
}
