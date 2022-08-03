using System.ComponentModel.DataAnnotations;

namespace generic_repository_pattern.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        
        public Shop? Shop { get; set; }
        IList<CustomerPurchasesProduct> customerPurchasesProducts { get; set; }

    }
}
