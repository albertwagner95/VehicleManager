using AutoMapper;
using VehicleManager.Application.Mapping;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class DeleteVehicleVm : IMapFrom<Domain.Model.VehicleModels.Vehicle>
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteVehicleVm, Domain.Model.VehicleModels.Vehicle>().ReverseMap()
                .ForMember(opt => opt.Name, x => x.MapFrom(v => string.Concat(v.VehicleBrandName, " ", v.Model)));
        }
    }
}
