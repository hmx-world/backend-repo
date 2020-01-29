using System;
using System.ComponentModel.DataAnnotations;

namespace tinder4apartment.Models
{
    public class RentalProperty : BasicProperty
    {
        public int Id { get; set; }
         [Required]
        public int Light24hours { get; set; }
         [Required]
        public bool WaterSupply { get; set; }
       
    }
}