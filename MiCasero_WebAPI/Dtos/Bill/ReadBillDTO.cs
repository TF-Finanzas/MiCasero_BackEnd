using Microsoft.EntityFrameworkCore;

namespace MiCasero_WebAPI.Dtos.Bill
{
    public class ReadBillDTO
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public bool IsNominalRate { get; set; }
        public bool IsEffectiveRate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsFrenchMethod { get; set; }
        public decimal InitialFee { get; set; }
        public decimal MoratoriumRate { get; set; }
        public decimal Balance { get; set; }
        public int? CustomerId { get; set; }
    }
}
