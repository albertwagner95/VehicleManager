using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Domain.Model.VehicleModels
{
    public class KindOfEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
