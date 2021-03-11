using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class UserCarsForListVm : IMapFrom<Domain.Model.VehicleModels.Vehicle>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserCarsForListVm, Domain.Model.VehicleModels.Vehicle>().ReverseMap()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => string.Concat(x.VehicleBrandName.Name, " ", x.Model, " ", x.RegistrationNumber)));
        }
    }
}
