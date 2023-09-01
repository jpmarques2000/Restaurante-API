using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.Models;
using RestauranteAPI.Interface;
using RestauranteAPI.Repository;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("Cardapio")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _cardapioRepository;
        private readonly ILogger<MealsController> _logger;

        public MenuController(IMenuRepository cardapioRepository, ILogger<MealsController> logger)
        {
            _cardapioRepository = cardapioRepository;
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
            return Ok(_cardapioRepository.GetAll());
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
            return Ok(_cardapioRepository.GetById(id));
        }

        /// <summary>
        /// Criar novo cardápio
        /// </summary>
        /// <param name="cardapioDTO"></param>
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
        public IActionResult CreateNewMenu(AddNewMenuDTO cardapioDTO)
        {
            _cardapioRepository.AddNew(new Menu(cardapioDTO));
            return Ok("Cardápio cadastrado com sucesso!");
        }

        /// <summary>
        /// Atualizar cardápio
        /// </summary>
        /// <param name="cardapioDTO"></param>
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
        public IActionResult UpdateMenuAsync(AlterarCardapioDTO cardapioDTO)
        {
            _cardapioRepository.Update(new Menu(cardapioDTO));
            return Ok("Cardápio alterada com sucesso");
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
            _cardapioRepository.Delete(id);
            return Ok("Cardápio removido com sucesso");
        }
    }
}
