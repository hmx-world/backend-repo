namespace tinder4apartment.Models
{
    public class UserQuery
    {
        public string City { get; set; }
        public string State { get; set; }
        public int NumberofAdult { get; set; }
        public int NumberofChildren { get; set; }
        public int minPrice {get; set;}
        public double maxPrice {get; set;}
    }
}