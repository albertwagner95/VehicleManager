using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;

namespace VehicleManager.Application.ViewModels
{
    public class VehicleFuelTypeVm : IMapFrom<VehicleFuelType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleFuelType, VehicleFuelTypeVm>();
        }
    }
}
