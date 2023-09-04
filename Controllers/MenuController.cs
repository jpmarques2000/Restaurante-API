using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.Models;
using RestauranteAPI.Interface;
using RestauranteAPI.Repository;
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
        public IActionResult GetMenus()
        {
            return Ok(_menuRepository.GetAll());
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
        public IActionResult GetMenusById(int id)
        {
            return Ok(_menuRepository.GetById(id));
        }

        /// <summary>
        /// Criar novo cardápio
        /// </summary>
        /// <param name="menuDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome do cardápio
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public IActionResult CreateNewMenu(AddNewMenuDTO menuDTO)
        {
            _menuRepository.AddNew(new Menu(menuDTO));
            return Ok("Cardápio cadastrado com sucesso!");
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
        public IActionResult UpdateMenuAsync(UpdateMenuDTO menuDTO)
        {
            _menuRepository.UpdateMenuAsync(menuDTO);
            return Ok("Cardápio alterada com sucesso");
        }

        [HttpPost("add-meal-to-menu")]
        public IActionResult AddNewMealToMenu(AddMealToMenuDTO newMenuMeal)
        {
             _menuRepository.AddNewMealToMenu(newMenuMeal);
            return Ok("Refeição adicionado ao cardárpio");
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
        [HttpDelete]
        public IActionResult DeleteMenu(int id)
        {
            _menuRepository.Delete(id);
            return Ok("Cardápio removido com sucesso");
        }
    }
}
