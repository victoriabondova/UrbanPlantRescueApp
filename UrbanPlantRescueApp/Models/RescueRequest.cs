using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanPlantRescueApp.Models
{
    public class RescueRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RequesterId { get; set; } = null!;
        [ForeignKey(nameof(RequesterId))]
        public virtual IdentityUser Requester { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Plant))]
        public int PlantId { get; set; }
        public virtual Plant Plant { get; set; } = null!;
        [Required]
        public DateTime RequestedOn { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; } = false;
    }
}
