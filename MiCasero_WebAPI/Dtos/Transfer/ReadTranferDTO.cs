namespace MiCasero_WebAPI.Dtos.Transfer
{
    public class ReadTranferDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public decimal Amount { get; set; }
        public int? BillId { get; set; }
    }
}
