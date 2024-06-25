using MiCasero_WebAPI.Dtos.Owner;
using MiCasero_WebAPI.Models;

namespace MiCasero_WebAPI.Mappers
{
    public static class OwnerMappers
    {
        public static OwnerDTO ToOwnerDTO(this Owner owner)
        {
            return new OwnerDTO
            {
                Id = owner.Id,
                Username = owner.Username,
                Password = owner.Password
            };
        }
        public static Owner FromRegisterDtoToOwner(this RegisterOwnerDTO ownerdto)
        {
            return new Owner
            {
                Username = ownerdto.Username,
                Password = ownerdto.Password
            };
        }
    }
}
