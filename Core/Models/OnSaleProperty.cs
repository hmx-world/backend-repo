using System.ComponentModel.DataAnnotations.Schema;

namespace tinder4apartment.Models
{
    public class OnSaleProperty : BasicProperty
    {
        public int Id { get; set; }
        public string LandArea { get; set; }
        
        public string  Title { get; set; }
        public string SiteDescription { get; set; }

        public Firm Firm { get; set; }
        
       public int FirmId { get; set; }

    }
}