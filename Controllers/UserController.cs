using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.User;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<MealsController> _logger;

        public UserController(IUserRepository userRepository, ILogger<MealsController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos usuários cadastrados
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> GetUsers()
        {
            return Ok( await _userRepository.GetAllUser());
        }

        /// <summary>
        /// Obtém usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> GetById(int id)
        {
            return Ok(await _userRepository.GetUserById(id));
        }

        /// <summary>
        /// Cadastra novo usuário
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome, Nome de usuário e Senha
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> AddNewUser(AddNewUserDTO userDTO)
        {
            return Ok(await _userRepository.AddUser(userDTO));
        }

        /// <summary>
        /// Altera dados do usuário já cadastrado
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome, Nome de usuário e Senha
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response> 
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> UpdateUser(UpdateUserDTO userDTO)
        {
            return Ok(await _userRepository.UpdateUser(userDTO));
        }

        /// <summary>
        /// Deletar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id de usuário a ser removido
        /// </remarks>
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetUserDTO>>> DeleteUser(int id)
        {
            return Ok(await _userRepository.DeleteUser(id));
        }
    }
}
