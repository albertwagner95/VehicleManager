using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class ZipCode:BaseField
    {
         
        public Address Address { get; set; }
    }
}