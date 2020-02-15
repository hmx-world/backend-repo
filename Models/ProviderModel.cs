using System.Collections.Generic;

namespace tinder4apartment.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}

        public string ImageUri {get; set;}

        public string PasswordHash {get; set;}
        public string PasswordSalt {get; set;}

        public IList<OnSaleProperty> OnSaleProperties {get; set;} 
        public IList<RentalProperty> RentalProperties {get; set;}
        public IList<IndustrialProperty> IndustrialProperty { get; set; }
        

        public string LoginId {get; set;}
    }
}