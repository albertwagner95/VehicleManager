using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleService : BaseField
    {
        public string ServiceDescribe { get; set; }
        public decimal Cost { get; set; }
        public int NextService { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}