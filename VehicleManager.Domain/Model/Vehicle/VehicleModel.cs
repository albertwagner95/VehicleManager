using System.ComponentModel.DataAnnotations;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class VehicleModel : BaseField
    {
        public Vehicle Vehicle { get; set; }
    }
}