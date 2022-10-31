using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Delivery.Entities
{
    public class Location
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Latitude { get; set; } = string.Empty;

        [Required]
        public string Longitude { get; set; } = string.Empty;
    }
}
