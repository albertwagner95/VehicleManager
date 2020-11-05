using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBirth { get; set; }
        public int Pesel { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
