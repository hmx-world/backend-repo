namespace tinder4apartment.Models
{
    public class CommercialQuery
    {
        public double minPrice {get; set;}
        public double maxPrice {get; set;}
        public string  City { get; set; }
        public string State { get; set; }
        public int NumberOfRooms { get; set; }
        
    }
}