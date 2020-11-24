using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class DeleteVehicleVm : IMapFrom<Domain.Model.Vehicle>
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteVehicleVm, Domain.Model.Vehicle>().ReverseMap()
                .ForMember(opt => opt.Name, x => x.MapFrom(v => String.Concat(v.VehicleBrandName, " ", v.Model)));
        }
    }
}
