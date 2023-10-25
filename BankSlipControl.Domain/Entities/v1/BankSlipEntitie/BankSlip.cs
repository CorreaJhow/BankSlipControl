using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankSlipControl.Domain.Entities.v1.BankSlipEntitie
{
    public class BankSlip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string PayerName { get; set; }

        [Required]
        public string DocumentPayer { get; set; }

        [Required]
        public string BeneficiaryName { get; set; }

        [Required]
        public string DocumentBeneficiary { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public string Observation { get; set; }

        [ForeignKey("BankId")]
        public int BankId { get; set; }
    }
}
