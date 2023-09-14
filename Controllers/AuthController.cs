using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Data;
using RestauranteAPI.DTO.User;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;
using RestauranteAPI.Services;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// Registra novo usuário no sistema
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome de usuário, nome e senha
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO userData)
        {
            var response = await _authRepository.Register(
                new Models.User 
                { NomeUsuario = userData.NomeUsuario,
                  Nome = userData.Nome },userData.Senha!);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// Realiza login no sistema
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        /// <remarks>
        /// Insira nome de usuário e senha 
        /// </remarks>
        /// <response code="200">Retorna Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDTO userData)
        {
            var response = await _authRepository.Login(userData.NomeUsuario, userData.Senha);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
