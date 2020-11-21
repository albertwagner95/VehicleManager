using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Domain.Model.AddressModels
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityTypeId { get; set; }
        public virtual CityType CityType { get; set; }
        public string CommunityId { get; set; }
        public virtual Community Community { get; set; }
        public string DistrictId { get; set; }
        public virtual District District { get; set; }
        public string VoivodeshipId { get; set; }
        public virtual Voivodeship Voivodeship { get; set; }
    }
}
