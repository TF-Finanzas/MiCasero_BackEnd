using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<List<ReadCustomerDTO?>> ReadCustomer(int id);
        Task<Customer> CreateCustomer(CreateCustomerDTO customer_dto);
        Task<Customer?> DeleteCustomer(int id);
        Task<Customer?> UpdateFinancial(int id, decimal credit);
        Task GetBalance(int id);
    }
}
