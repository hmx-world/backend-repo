namespace server.Core.Models
{
    public class LandPropertyQuery
    {
        public string City { get; set; }
        public string State { get; set; }

        public double area {get; set;}
        public double minPrice {get; set;}
        public double maxPrice {get; set;}
    }
}