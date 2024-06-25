using MiCasero_WebAPI.Data;
using MiCasero_WebAPI.Dtos.Bill;
using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Dtos.Transfer;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace MiCasero_WebAPI.Services
{
    public class TransferService : ITransferService
    {
        private readonly ApplicationDBContext _dbContext;
        public TransferService(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Transfer> CreateInterest(decimal interest, int id)
        {
            Transfer transfer = new Transfer
            {
                Name = "Interest",
                Amount = interest,
                BillId = id 
            };
            await _dbContext.Transfers.AddAsync(transfer);
            await _dbContext.SaveChangesAsync();
            return transfer;
        }

        public async Task<Transfer> CreateTranfer(CreateTransferDTO transfer_dto)
        {
            var transfers = transfer_dto.FromCreateTransferDTOToTransfer();
            await _dbContext.Transfers.AddAsync(transfers);
            await _dbContext.SaveChangesAsync();
            return transfers;
        }

        public async Task<Transfer> DeleteTransfer(int id)
        {
            var transfer = await _dbContext.Transfers.FirstOrDefaultAsync(x => x.Id == id);
            if (transfer == null)
            {
                return null;
            }
            _dbContext.Transfers.Remove(transfer);
            await _dbContext.SaveChangesAsync();
            return transfer;
        }

        public async Task<List<ReadTranferDTO?>> ReadTransfer(int id)
        {
            var transfers = await _dbContext.Transfers.Where(x => x.BillId == id)
                                .Select(transfer => (ReadTranferDTO?) transfer.ToReadTransferDTO())
                                .ToListAsync();
            return transfers;
        }
    }
}
