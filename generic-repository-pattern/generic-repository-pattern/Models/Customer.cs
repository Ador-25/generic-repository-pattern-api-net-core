using System.ComponentModel.DataAnnotations;

namespace generic_repository_pattern.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerAddress { get; set; }

        ICollection<CustomerPurchasesProduct> customerPurchasesProducts { get; set; }
    }
}
