using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestauranteAPI.Models;
using RestauranteAPI.Repository;
using RestauranteAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestauranteAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(string usuario, string senha)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.NomeUsuario!.ToLower().Equals(usuario.ToLower()));
            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Usuário não encontrado.";
            }
            else if (!VerifyPasswordHash(senha, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Senha incorreta, por favor verifique.";
            }
            else
            {
                serviceResponse.Data = GenerateToken(user);
            }
            serviceResponse.Message = "Autenticado com sucesso.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> Register(User user, string senha)
        {
            var serviceResponse = new ServiceResponse<int>();
            if (await UserExists(user.NomeUsuario!))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Usuário já existente no sistema.";
                return serviceResponse;
            }

            CreatePasswordHash(senha, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = user.Id;
            serviceResponse.Message = "Novo usuário criado com sucesso.";
            return serviceResponse;
        }

        public async Task<bool> UserExists(string usuario)
        {
            if (await _context.User.AnyAsync(u => u.NomeUsuario!.ToLower() == usuario.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.NomeUsuario)
            };

            var appToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appToken is null)
                throw new Exception("AppSettings Token não foi preenchida, favor verificar");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(appToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
