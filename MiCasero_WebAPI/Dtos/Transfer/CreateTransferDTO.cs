namespace MiCasero_WebAPI.Dtos.Transfer
{
    public class CreateTransferDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int? BillId { get; set; }
    }
}
