using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tinder4apartment.Models
{
    public class RentalProperty : BasicProperty
    {
        public int Id { get; set; }
         [Required]
        public int Light24hours { get; set; }
         [Required]
        public bool WaterSupply { get; set; }

        public virtual Firm Firm { get; set; }
        
        public int FirmId { get; set; }

        public bool RefundableCautionDeposit {get; set; }

        public double RefundableCautionDepositPrice {get; set;}
    }
}