using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class VoivodeshipVm : IMapFrom<Voivodeship>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VoivodeshipVm, Voivodeship>().ReverseMap();
        }
    }
}
