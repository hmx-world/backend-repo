using System.ComponentModel.DataAnnotations;

namespace tinder4apartment.Models
{
    public class ProviderData
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
         [Required]
        public string Email { get; set; }
         [Required]
        public string FirmDescription { get; set; }
         [Required]
        public string Location { get; set; }
    }
}