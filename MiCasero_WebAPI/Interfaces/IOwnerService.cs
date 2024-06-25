using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Interfaces
{
    public interface IOwnerService
    {
        Task<OwnerDTO?> Login(RegisterOwnerDTO ownerdto);
        Task<Owner> Register(RegisterOwnerDTO ownerdto);
        Task<Owner?> Delete(int id);
    }
}
