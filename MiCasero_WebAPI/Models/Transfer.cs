using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiCasero_WebAPI.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Precision(8,2)]
        [Required]
        public decimal Amount { get; set; }
        public int? BillId { get; set; }
        public Bill? Bill { get; set; }
    }
}
