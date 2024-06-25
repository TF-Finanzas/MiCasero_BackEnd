using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MiCasero_WebAPI.Mappers
{
    public static class CustomerMapper
    {
        public static Customer FromCreateCustomerDTOToCustomer(this CreateCustomerDTO customer_dto)
        {
            return new Customer
            {
                Name = customer_dto.Name,
                DateBirth = customer_dto.DateBirth,
                Email = customer_dto.Email,
                PhoneNumber = customer_dto.PhoneNumber,
                DNI = customer_dto.DNI,
                RUCEmployer = customer_dto.RUCEmployer,
                Address = customer_dto.Address,
                Payday = customer_dto.Payday,
                OwnerId = customer_dto.OwnerId,
            };
        }
        public static ReadCustomerDTO ToReadCustomerDTO(this Customer customer)
        {
            return new ReadCustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                DateBirth = customer.DateBirth,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                DNI = customer.DNI,
                RUCEmployer = customer.RUCEmployer,
                Address = customer.Address,
                CreditLimit = customer.CreditLimit,
                Balance = customer.Balance,
                IsApproved = customer.IsApproved,
                Payday = customer.Payday,
                OwnerId = customer.OwnerId
            };
        }
    }
}
