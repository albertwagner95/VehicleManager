using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Domain.Model.AddressModels
{
    public class Voivodeship
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
