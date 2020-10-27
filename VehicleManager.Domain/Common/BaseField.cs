using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Domain.Common
{
    public class BaseField : AuditableModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}