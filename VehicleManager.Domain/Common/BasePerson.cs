using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManager.Domain.Common
{
    public class BasePerson : BaseField
    {
        public string Surname { get; set; }
        public DateTime DateBirth { get; set; }
        public int? Pesel { get; set; }
    }
}
