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
        public IActionResult GetUsers()
        {
            return Ok(_userRepository.GetAll());
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
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetById(id));
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
        public IActionResult AddNewUser(AddNewUserDTO userDTO)
        {
            _userRepository.AddNew(new User(userDTO));
            return Ok("Usuário cadastrado com sucesso.");
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
        public IActionResult UpdateUser(UpdateUserDTO userDTO)
        {
            _userRepository.UpdateUserAsync(userDTO);
            return Ok("Usuário alterado com sucesso.");
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
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("Usuário removido com sucesso.");
        }
    }
}
