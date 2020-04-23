namespace server.Core.Models
{
    public class EmergencyProperty
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
    }

    public enum PropertyType{
        ResidentialForSale, ResidentialForRent, CommercialForSale, CommercialForRent, LandProperty
    }
}