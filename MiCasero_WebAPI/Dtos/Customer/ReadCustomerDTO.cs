namespace MiCasero_WebAPI.Dtos.Customer
{
    public class ReadCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string RUCEmployer { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; set; }
        public bool IsApproved { get; set; }
        public int Payday { get; set; }
        public int? OwnerId { get; set; }
    }
}
