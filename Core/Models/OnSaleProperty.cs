namespace tinder4apartment.Models
{
    public class OnSaleProperty : BasicProperty
    {
        public int Id { get; set; }
        public string LandArea { get; set; }
        
        public string  Title { get; set; }
        public string SiteDescription { get; set; }

        public ProviderModel ProviderModel { get; set; }
        public int ProviderModelId { get; set; }

    }
}