using System;

namespace VehicleManager.Domain.Common
{
    public class AuditableModel
    { 
        public string CreatedById { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
