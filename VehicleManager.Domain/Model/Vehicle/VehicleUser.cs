using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleUser : BasePerson
    {

        public ICollection<Vehicle> Vehicles { get; set; }
        public Address Address { get; set; }

    }
}
