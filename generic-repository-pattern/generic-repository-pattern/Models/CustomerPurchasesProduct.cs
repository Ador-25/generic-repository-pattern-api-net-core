using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace generic_repository_pattern.Models
{
    public class CustomerPurchasesProduct
    {
        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
