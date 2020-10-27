using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Address> Addresses { get; set; }


    }
}
