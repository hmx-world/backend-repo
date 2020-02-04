namespace tinder4apartment.Models
{
    public class PropertyLogs
    {
        public int Id { get; set; }
        public string PropertyId { get; set; }
        public string  ProviderId { get; set; }
        public string  ActionDate { get; set; }
        public string ClientId {get; set;}
        public string ClientLocation {get; set;}
    }
}