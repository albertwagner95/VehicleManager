using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class VehicleBrandNameVm : IMapFrom<VehicleBrandName>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; internal set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<VehicleBrandName, VehicleBrandNameVm>();
        }
    }


}
