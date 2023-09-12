using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.User;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EFUserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddNewUserDTO newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            var user = _mapper.Map<User>(newUser);

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.User
                    .Where(u => u.Id == user.Id)
                    .Select(user => _mapper.Map<GetUserDTO>(user))
                    .ToListAsync();

            serviceResponse.Message = "Usuário adicionado com sucesso.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            try
            {
                var user = await GetById(id);
                if (user is null)
                    throw new Exception($"Usuário com id '{id}' não encontrado");

                _context.User.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.User.Where(u => u.Id == id)
                    .Select(user => _mapper.Map<GetUserDTO>(user)).ToListAsync();
                        
                serviceResponse.Message = "Usuário removido com sucesso!";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUser()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();

            var users = await _context.User.ToListAsync();

            serviceResponse.Data = users.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();
            serviceResponse.Message = "Lista de usuários cadastrados";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                var user = _context.User.FirstOrDefault(u => u.Id == updatedUserDTO.Id);
                if (user is null)
                    throw new Exception($"Usuário com Id '{updatedUserDTO.Id} não encontrado.'");

                user.Nome = updatedUserDTO.Nome;
                user.NomeUsuario = updatedUserDTO.NomeUsuario;
                user.Senha = updatedUserDTO.Senha;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
                serviceResponse.Message = $"Usuário com id '{updatedUserDTO.Id} alterado com sucesso.'";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user is null)
                throw new Exception($"Usuário com id '{id}' não foi encontrado.");

            return user;
        }

        public async Task<ServiceResponse<GetUserDTO>> LoginUser(LoginDTO userData)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            var user = await _context.User.FirstOrDefaultAsync(user =>
                user.NomeUsuario == userData.NomeUsuario && user.Senha == userData.Senha);

            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);

            return serviceResponse;
        }
    }
}
