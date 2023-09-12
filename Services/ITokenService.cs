using RestauranteAPI.Models;

namespace RestauranteAPI.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
