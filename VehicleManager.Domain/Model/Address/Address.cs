using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class Address : AuditableModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        [Required]
        public string BuildigNumber { get; set; }
        public int FlatNumber { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int VehicleUserRef { get; set; }
        public virtual VehicleUser VehicleUser { get; set; }
        public int VehicleOwnerRef { get; set; }
        public virtual VehicleOwner VehicleOwner { get; set; }
        public int AddressTypeRef { get; set; }
        public virtual AddressType AddressType { get; set; }

        public int CityRef { get; set; }
        public virtual City City { get; set; }

        public int ZipCodeRef { get; set; }
        public virtual ZipCode ZipCode { get; set; }

        public int CountryRef { get; set; }
        public virtual Country Country { get; set; }


    }
}
