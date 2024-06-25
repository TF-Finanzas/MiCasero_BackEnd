using MiCasero_WebAPI.Dtos.Transfer;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Mappers
{
    public static class TransferMapper
    {
        public static Transfer FromCreateTransferDTOToTransfer(this CreateTransferDTO transfer_dto)
        {
            return new Transfer
            {
                Name = transfer_dto.Name,
                Amount = transfer_dto.Amount,
                BillId = transfer_dto.BillId
            };
        }
        public static ReadTranferDTO ToReadTransferDTO(this Transfer transfer)
        {
            return new ReadTranferDTO
            {
                Id = transfer.Id,
                Name = transfer.Name,
                StartDate = transfer.StartDate,
                Amount = transfer.Amount,
                BillId = transfer.BillId
            };
        }
    }
}
