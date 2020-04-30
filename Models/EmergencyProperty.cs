namespace server.Core.Models
{
    public class EmergencyProperty
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
    }

    public enum PropertyType{
        OnSale, Rental, Commercial, LandProperty
    }


    public class EmergencyPropertyDTO : EmergencyProperty
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string PropertyLocation {get; set;}

        public new string PropertyType {get; set;}

        public string FirmName {get; set;}
        public string FirmLocation { get; set; }
    }
}