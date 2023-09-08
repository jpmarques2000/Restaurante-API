using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.Models;
using RestauranteAPI.Interface;
using RestauranteAPI.DTO.MenuDTO;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("Cardapio")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<MealsController> _logger;

        public MenuController(IMenuRepository menuRepository, ILogger<MealsController> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os cardápios cadastrados
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetMenuDTO>>> GetMenu()
        {
            return Ok(await _menuRepository.GetAllMenus());
        }

        /// <summary>
        /// Obtém cardápio por Id
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
        public async Task<ActionResult<ServiceResponse<List<GetMenuDTO>>>> GetMenusById(int id)
        {
            return Ok(await _menuRepository.GetMenuById(id));
        }

        /// <summary>
        /// Adiciona novo cardápio
        /// </summary>
        /// <param name="menuDto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Inserir nome do cardápio
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMenuDTO>>>> AddMenu(AddMenuDTO menuDto)
        {
            return Ok(await _menuRepository.AddMenu(menuDto));
        }

        /// <summary>
        /// Atualizar cardápio
        /// </summary>
        /// <param name="menuDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id e novo nome do cardápio
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetMenuDTO>>>> UpdateMenu(UpdateMenuDTO menuDTO)
        {
            return Ok(await _menuRepository.UpdateMenu(menuDTO));
        }

        /// <summary>
        /// Adiciona nova refeição ao menu
        /// </summary>
        /// <param name="newMenuMeal"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do menu e Id da refeição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost("add-meal-to-menu")]
        public async Task<ActionResult<ServiceResponse<GetMenuDTO>>> AddNewMealToMenu(AddMealToMenuDTO newMenuMeal)
        {
            return Ok(await _menuRepository.AddNewMealToMenu(newMenuMeal));
        }

        /// <summary>
        /// Exclui cardápio existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do cardápio a ser removido
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetMenuDTO>>> DeleteMenu(int id)
        {
            return Ok(await _menuRepository.DeleteMenu(id));
        }
    }
}
