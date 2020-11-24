using System.Collections.Generic;

namespace VehicleManager.Domain.Model.AddressModels
{
    public class Community
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
