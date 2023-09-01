using AutoMapper;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUserAsync(UpdateUserDTO updatedUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                var user = GetById(updatedUserDTO.Id);
                if (user is null)
                    throw new Exception($"Usuário com Id '{updatedUserDTO.Id} não encontrado.'");

                user.Nome = updatedUserDTO.Nome;
                user.NomeUsuario = updatedUserDTO.NomeUsuario;
                user.Senha = updatedUserDTO.Senha;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
