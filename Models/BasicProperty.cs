using System.ComponentModel.DataAnnotations;

namespace tinder4apartment.Models
{
    public class BasicProperty
    {
         [Required]
        public string  Name { get; set; }
         [Required]
        public double Price { get; set; }
         [Required]
        public string City { get; set; }
         [Required]
         
        public string State {get; set;}
        
         [Required]
         public int NumberOfBedrooms { get; set; }
         [Required]
         public int NeighbourhoodSecurity { get; set; }
        public string Extras { get; set; }
         [Required]
         public string BuildingType { get; set; }
         [Required]
         public string ProviderName { get; set; }
         [Required]
         public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string ImageLink3 { get; set; }

        public bool IsActive { get; set; }
    }
}