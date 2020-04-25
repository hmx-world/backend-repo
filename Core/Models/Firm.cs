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
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
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

        public string PhoneNumber {get; set;}

        public Plan Plan {get; set;}
    }
}