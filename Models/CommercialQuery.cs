using System.ComponentModel.DataAnnotations;

namespace tinder4apartment.Models
{
    public class CommercialQuery
    {
        [Required]
        public double minPrice {get; set;}
        [Required]
        public double maxPrice {get; set;}
        [Required]
        public string  City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public Purpose purpose {get; set;}
        
    }
}