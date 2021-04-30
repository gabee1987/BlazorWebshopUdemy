using System.ComponentModel.DataAnnotations;
namespace eShop.CoreBusiness.Models
{
    public class Customer
    {
        [Required]
        [StringLength( 100 )]
        public string FirstName { get; set; }
        [Required]
        [StringLength( 100 )]
        public string LastName { get; set; }
        [Required]
        [Range( 1, 1000 )]
        public int CustomerNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
