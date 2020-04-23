using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using tinder4apartment.Models;

namespace server.Core.Models
{
    public class LandProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double AreaSize { get; set; }
        public string Title { get; set; }
        public bool IsActive {get; set;}

        [NotMapped]
        public IFormFile imageFile1 {get; set;}
         [NotMapped]
        public IFormFile imageFile2 {get; set;}
         [NotMapped]
        public IFormFile imageFile3 {get; set;}
          public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string ImageLink3 { get; set; }
        public ProviderModel ProviderModel {get; set;}
        public int ProviderModelId { get; set; }
    }
}