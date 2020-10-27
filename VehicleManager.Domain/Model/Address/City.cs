using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class City : BaseField
    {
        public Address Address { get; set; }
    }
}