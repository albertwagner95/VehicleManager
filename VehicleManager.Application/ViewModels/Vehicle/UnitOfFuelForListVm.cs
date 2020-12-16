using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class UnitOfFuelForListVm : IMapFrom<UnitOfFuel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnitOfFuelForListVm, UnitOfFuel>().ReverseMap();
        }
    }
}
