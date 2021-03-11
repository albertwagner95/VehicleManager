using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model.VehicleModels
{
    public class CarHistory : AuditableModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EventRef { get; set; }
        public Event Event { get; set; }
        public DateTime EventDate { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
