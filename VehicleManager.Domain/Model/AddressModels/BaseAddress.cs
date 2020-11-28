namespace VehicleManager.Domain.Model.AddressModels
{
    public class BaseAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string Community { get; set; }
        public string District { get; set; }
        public string Voivodoship { get; set; }
    }
}
