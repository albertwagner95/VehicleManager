using System.ComponentModel.DataAnnotations;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleType:BaseField
    { 
        [Required]
        public int EnginePower { get; set; } //kw
        [Required]
        public int EngineCapacity { get; set; }
        [Required]
        public int PermissibleGrossWeight { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int OwnWeight { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}