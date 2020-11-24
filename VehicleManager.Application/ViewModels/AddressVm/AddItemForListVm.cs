using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class AddItemForListVm:IMapFrom<Address>
    {
        public string Street { get; set; }
        public string BuildigNumber { get; set; }
        public int FlatNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Vehicle, AddItemForListVm>().ReverseMap();
        }
    }
}
