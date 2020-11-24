using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model.AddressModels
{
    public class Address : AuditableModel
    {
        public int Id { get; set; }
        public string Voivodeship { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Community { get; set; }
        public string CityType { get; set; }
        public string BuildigNumber { get; set; }
        public int FlatNumber { get; set; }
        public string StreetFromUser { get; set; }
        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
