using System.ComponentModel.DataAnnotations;

namespace MiCasero_WebAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Username { get; set; } = string.Empty;
        [MaxLength(25)]
        [Required]
        public string Password { get; set; } = string.Empty;
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
