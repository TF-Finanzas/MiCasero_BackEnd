using MiCasero_WebAPI.Data;
using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiCasero_WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerService(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public async Task<Customer> CreateCustomer(CreateCustomerDTO customer_dto)
        {
            var customer = customer_dto.FromCreateCustomerDTOToCustomer();
            customer.IsApproved = true;
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return null;
            }
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task GetBalance(int id)
        {
            decimal balance = await _dbContext.Bills.Where(x => x.CustomerId == id).SumAsync(x => x.Balance);
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                customer.Balance = balance;
                if(customer.CreditLimit > balance)
                {
                    customer.IsApproved = true;
                }
                else
                {
                    customer.IsApproved = false;
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ReadCustomerDTO?>> ReadCustomer(int id)
        {
            var customers = await _dbContext.Customers.Where(x => x.OwnerId == id)
                                .Select(customer => (ReadCustomerDTO?) customer.ToReadCustomerDTO())
                                .ToListAsync();
            return customers;
        }

        public  async Task<Customer?> UpdateFinancial(int id, decimal credit)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return null;
            }
            customer.CreditLimit = credit;
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
