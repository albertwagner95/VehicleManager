using System.Collections.Generic;

namespace VehicleManager.Domain.Model.AddressModels
{
    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }

}
