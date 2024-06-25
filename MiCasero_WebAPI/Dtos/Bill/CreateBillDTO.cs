namespace MiCasero_WebAPI.Dtos.Bill
{
    public class CreateBillDTO
    {
        public DateOnly FinishDate { get; set; }
        public bool IsNominalRate { get; set; }
        public bool IsEffectiveRate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsFrenchMethod { get; set; }
        public decimal MoratoriumRate { get; set; }
        public decimal InitialFee { get; set; }
        public int? CustomerId { get; set; }
    }
}
