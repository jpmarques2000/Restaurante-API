using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;
using RestauranteAPI.Services;

namespace RestauranteAPI.DTO.UserDTO
{
    [ApiController]
    [Route("login")]
    public class LoginController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Realizar login no sistema
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Insira nome de usuário e senha 
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        //[HttpPost]
        //public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDTO userDTO)
        //{
        //    var user = await _userRepository.LoginUser(userDTO);
        //    if (user == null)
        //        return NotFound(new { mensagem = "Usuário ou senha inválidos" });
        //    var token = _tokenService.GenerateToken(user);

        //    user.Senha = null;

        //    return Ok(new
        //    {
        //        Usuario = user,
        //        Token = token
        //    });

        //}
    }
}
