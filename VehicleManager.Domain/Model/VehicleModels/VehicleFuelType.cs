using System.Collections.Generic;
using VehicleManager.Domain.Common;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Model
{
    public class VehicleFuelType : BaseField
    {
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
