using System.Collections.Generic;

namespace tinder4apartment.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Password {get; set;}
        public string Email {get; set;}
        public string ImageUri { get; set; }

        public List<IndustrialProperty> IndustrialProperties { get; set; }
        public List<OnSaleProperty> OnSaleProperties {get; set;}
        public List<RentalProperty> RentalProperties { get; set; }
    }
}