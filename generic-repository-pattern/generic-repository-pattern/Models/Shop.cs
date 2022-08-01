using System.ComponentModel.DataAnnotations;

namespace generic_repository_pattern.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        [EmailAddress]
        public string ShopEmail { get; set; }
        [Required]
        public string ShopAddress { get; set; }
        [Required]
        public string PhoneNumner { get; set; }
    }
}
