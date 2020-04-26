using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using server.Core.Models;

namespace tinder4apartment.Models
{
    public class Firm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public string ImageUri { get; set; }

        public string  PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public IList<OnSaleProperty> OnSaleProperties { get; set; }
        public IList<RentalProperty> RentalProperties { get; set; }
        public IList<CommercialProperty> CommercialProperty { get; set; }
        public IList<LandProperty> LandProperties {get; set;}

        [NotMapped]
        public IFormFile imageFile1 { get; set; }

        public string LoginId { get; set; }
        [Required]
        public string PhoneNumber {get; set;}

        public Plan Plan {get; set;}
    }
}