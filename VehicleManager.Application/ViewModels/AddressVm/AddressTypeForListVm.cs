using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class AddressTypeForListVm : IMapFrom<AddressType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddressTypeForListVm, AddressType>().ReverseMap();
        }
    }
}
