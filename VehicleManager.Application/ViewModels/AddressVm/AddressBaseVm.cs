using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.AddressModels;

namespace VehicleManager.Application.ViewModels.AddressVm
{
    public class AddressBaseVm : IMapFrom<BaseAddress>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string Community { get; set; }
        public string District { get; set; }
        public string Voivodoship { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddressBaseVm, BaseAddress>().ReverseMap();
        }
    }
}
