using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiCasero_WebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateOnly DateBirth { get; set; }
        [MaxLength(35)]
        [Required]
        public string Email { get; set; } = string.Empty;
        [MaxLength(9)]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(8)]
        [Required]
        public string DNI { get; set; } = string.Empty;
        [MaxLength(11)]
        [Required]
        public string RUCEmployer {  get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public string Address { get; set; } = string.Empty;
        [Precision(8,2)]
        [Required]
        public decimal CreditLimit { get; set; }
        [Precision(8, 2)]
        public decimal Balance { get; set; }
        public bool IsApproved { get; set; }
        [Precision(2)]
        [Required]
        public int Payday { get; set; }
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
