using System.ComponentModel.DataAnnotations;

namespace tinder4apartment.Models
{
    public class UserQuery
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int NumberofAdult { get; set; }
        [Required]
        public int NumberofChildren { get; set; }
        [Required]
        public double minPrice {get; set;}
        [Required]
        public double maxPrice {get; set;}
        [Required]
        public Purpose purpose {get; set;}
    }
}