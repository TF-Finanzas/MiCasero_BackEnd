using MiCasero_WebAPI.Dtos.Bill;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Mappers
{
    public static class BillMapper
    {
        public static Bill FromCreateBillDTOToBill(this CreateBillDTO bill_dto)
        {
            return new Bill
            {
                FinishDate = bill_dto.FinishDate,
                IsNominalRate = bill_dto.IsNominalRate,
                IsEffectiveRate = bill_dto.IsEffectiveRate,
                InterestRate = bill_dto.InterestRate,
                IsFrenchMethod = bill_dto.IsFrenchMethod,
                MoratoriumRate = bill_dto.MoratoriumRate,
                InitialFee = bill_dto.InitialFee,
                CustomerId = bill_dto.CustomerId,
            };
        }
        public static ReadBillDTO ToReadBillDTO(this Bill bill)
        {
            return new ReadBillDTO
            {
                Id = bill.Id,
                StartDate = bill.StartDate,
                FinishDate = bill.FinishDate,
                IsNominalRate = bill.IsNominalRate,
                IsEffectiveRate = bill.IsEffectiveRate,
                InterestRate = bill.InterestRate,
                IsFrenchMethod = bill.IsFrenchMethod,
                MoratoriumRate = bill.MoratoriumRate,
                Balance = bill.Balance,
                InitialFee = bill.InitialFee,
                CustomerId = bill.CustomerId
            };
        }
    }
}
