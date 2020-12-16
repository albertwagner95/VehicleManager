using AutoMapper;
using VehicleManager.Application.Mapping;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Application.ViewModels.Vehicle
{
    public class FuelTypeForRefuelingForListVm : IMapFrom<FuelForRefueling>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FuelForRefueling, FuelTypeForRefuelingForListVm>();
        }
    }
}