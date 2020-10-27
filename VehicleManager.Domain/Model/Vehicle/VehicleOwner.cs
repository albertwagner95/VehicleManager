using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleOwner : BasePerson
    {
        public ICollection<Vehicle> Vehicles { get; set; }
        public Address Address { get; set; }

    }
}