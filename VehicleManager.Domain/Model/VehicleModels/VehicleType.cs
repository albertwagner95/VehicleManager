using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model.VehicleModels
{
    public class VehicleType : BaseField
    {
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
