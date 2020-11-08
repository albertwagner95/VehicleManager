using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices.ComTypes;
using VehicleManager.Domain.Common;

namespace VehicleManager.Domain.Model
{
    public class Country : BaseField
    {
        public string TwoCharactersoutryCode { get; set; }
        public string ThreeCharactersoutryCode { get; set; }
        public Address Address { get; set; }
        //public Vehicle Vehicle { get; set; }

    }
}