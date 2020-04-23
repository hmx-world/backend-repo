namespace tinder4apartment.Models
{
    public class CommercialProperty : BasicProperty
    {
        public int Id { get; set; }        
        public double Area { get; set; }
        public bool ParkingSpace { get; set; }

        public Purpose Purpose {get; set;}
        public string Title {get; set;}
        public ProviderModel ProviderModel { get; set; }
        public int ProviderModelId { get; set; }
    }

    public enum Purpose
    {
        Sale, Rent
    } 
}