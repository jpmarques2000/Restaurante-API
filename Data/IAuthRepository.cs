using RestauranteAPI.Models;

namespace RestauranteAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string senha);
        Task<ServiceResponse<string>> Login(string usuario, string senha);
        Task<bool> UserExists(string usuario);
    }
}
