using AutoMapper;
using VehicleManager.Application.Mapping;
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
            profile.CreateMap<Domain.Model.VehicleModels.Vehicle, AddItemForListVm>().ReverseMap();
        }
    }
}
