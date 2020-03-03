using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace tinder4apartment.Models
{
    public class BasicProperty
    {
        [NotMapped]
        public IFormFile imageFile1 {get; set;}
         [NotMapped]
        public IFormFile imageFile2 {get; set;}
         [NotMapped]
        public IFormFile imageFile3 {get; set;}
         [NotMapped]
        public IFormFile VideoFIle {get; set;}
        
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
      
         public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string ImageLink3 { get; set; }

         public string VideoLink { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Town {get; set;}   
    }
}