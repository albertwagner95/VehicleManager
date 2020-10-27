using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class AddressType:AuditableModel
    {
        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public Address Address { get; set; }
    }

}
