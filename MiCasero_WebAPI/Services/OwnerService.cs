using MiCasero_WebAPI.Data;
using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiCasero_WebAPI.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDBContext _dbContext;
        public OwnerService(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public async Task<Owner?> Delete(int id)
        {
            var owner = await _dbContext.Owner.FirstOrDefaultAsync(x => x.Id == id);
            if (owner == null)
            {
                return null;
            }
            _dbContext.Owner.Remove(owner);
            await _dbContext.SaveChangesAsync();
            return owner;
        }

        public Task<OwnerDTO?> Login(RegisterOwnerDTO ownerdto)
        {
            return _dbContext.Owner.Where(x => x.Username == ownerdto.Username && x.Password == ownerdto.Password)
                                .Select(owner => owner.ToOwnerDTO())
                                .FirstOrDefaultAsync();
        }

        public async Task<Owner> Register(RegisterOwnerDTO ownerdto)
        {
            var owner = ownerdto.FromRegisterDtoToOwner();
            await _dbContext.Owner.AddAsync(owner);
            await _dbContext.SaveChangesAsync();
            return owner;
        }
    }
}
