using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<ServiceResponse<GetUserDTO>> UpdateUserAsync(UpdateUserDTO updatedUserDTO);
    }
}
