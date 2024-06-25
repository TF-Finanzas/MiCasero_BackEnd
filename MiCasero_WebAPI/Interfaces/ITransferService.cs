using MiCasero_WebAPI.Dtos.Transfer;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Interfaces
{
    public interface ITransferService
    {
        Task<Transfer> CreateTranfer(CreateTransferDTO transfer_dto);
        Task<List<ReadTranferDTO?>> ReadTransfer(int id);
        Task<Transfer> DeleteTransfer(int id);
        Task<Transfer> CreateInterest(decimal interest, int id);
    }
}
