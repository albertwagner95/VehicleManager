using System.Collections.Generic;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model.VehicleModels
{
    public class VehicleType : BaseField
    {
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
