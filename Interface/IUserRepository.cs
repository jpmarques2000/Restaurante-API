using RestauranteAPI.DTO.User;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IUserRepository 
    {
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUser();
        Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id);
    }
}
