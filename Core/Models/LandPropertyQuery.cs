using System.ComponentModel.DataAnnotations;

namespace server.Core.Models
{
    public class LandPropertyQuery
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public double area {get; set;}
        [Required]
        public double minPrice {get; set;}
        [Required]
        public double maxPrice {get; set;}
    }
}