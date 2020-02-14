namespace tinder4apartment.Models
{
    public class IndustrialProperty : BasicProperty
    {
        public int Id { get; set; }        
        public double Area { get; set; }
        public bool ParkingSpace { get; set; }

        public Mode Mode {get; set;}

        public ProviderModel ProviderModel { get; set; }
        public int ProviderModelId { get; set; }
    }

    public enum Mode
    {
        Sale, Rent
    } 
}