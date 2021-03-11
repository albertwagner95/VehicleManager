using System;
using System.Collections.Generic;
using System.Text;
using VehicleManager.Domain.Common;
using VehicleManager.Domain.Model.VehicleModels;

namespace VehicleManager.Domain.Model
{
    public class UnitOfFuel : AuditableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
