using MiCasero_WebAPI.Dtos;
using MiCasero_WebAPI.Dtos.Bill;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Interfaces
{
    public interface IBillService
    {
        Task<List<ReadBillDTO?>> ReadBill(int id);
        Task<Bill> CreateBill(CreateBillDTO bill_dto);
        Task<Bill?> DeleteBill(int id);
        Task<decimal> NominalRate(int id);
        Task<decimal> EffectiveRate(int id);
        Task<List<decimal>> FrenchMethod(int id);
        Task UpdateBalance(int id);
    }
}
