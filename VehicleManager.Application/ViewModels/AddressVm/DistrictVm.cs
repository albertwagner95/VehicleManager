using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class DistrictVm //: IMapFrom<District>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<DistrictVm, District>();
        //}
    }
}
