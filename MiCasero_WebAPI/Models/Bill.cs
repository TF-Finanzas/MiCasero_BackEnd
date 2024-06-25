using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiCasero_WebAPI.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly FinishDate { get; set; }
        public bool IsNominalRate { get; set; }
        public bool IsEffectiveRate { get; set; }
        [Precision(10, 7)]
        public decimal InterestRate { get; set; }
        [Precision(10, 7)]
        public decimal InitialFee { get; set; }
        public bool IsFrenchMethod { get; set; }
        [Precision(10, 7)]
        public decimal MoratoriumRate { get; set; }
        [Precision(8, 2)]
        public decimal Balance { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

    }
}
