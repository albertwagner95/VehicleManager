using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleFuelType : BaseField
    {
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
