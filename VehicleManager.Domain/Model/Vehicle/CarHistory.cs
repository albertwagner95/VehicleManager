using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class CarHistory : BaseField
    {

        [Required]
        [MaxLength(500)]
        public string EventDescribe { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}