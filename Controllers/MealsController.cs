using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("Refeicao")]
    public class MealsController : ControllerBase
    {
        private readonly IMealRepository _refeicaoRepository;
        private readonly ILogger<MealsController> _logger;

        public MealsController(IMealRepository refeicaoRepository, ILogger<MealsController> logger)
        {
            _refeicaoRepository = refeicaoRepository;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os pedidos da refeição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id da refeição para realizar requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("orders/{id}")]
        public IActionResult GetAllProductOrders(int id)
        {
            return Ok(_refeicaoRepository.GetOrders(id));
        }

        /// <summary>
        /// Obtém todas as refeições cadastradas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public IActionResult GetAllMeals() 
        { 
            return Ok(_refeicaoRepository.GetAll());
        }


        /// <summary>
        /// Obtém refeição por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar id para realizar requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet("get-by-meal-id/{id}")]
        public IActionResult GetByMealId(int id)
        {
            return Ok(_refeicaoRepository.GetById(id));
        }

        /// <summary>
        /// Cadastrar nova refeição
        /// </summary>
        /// <param name="refeicaoDTO"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome, Preço e Descrição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPost]
        public IActionResult NewMeal(AddNewMealDTO refeicaoDTO)
        {
             _refeicaoRepository.AddNew(new Meal(refeicaoDTO));
            return Ok("Refeição cadastrada com sucesso!");
        }

        /// <summary>
        /// Atualizar dados da refeição
        /// </summary>
        /// <param name="updateMeal"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id, Nome, Preço e Descrição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ICollection<GetMealDTO>>>> UpdateMeal(UpdateMealDTO updateMeal)
        {
            await _refeicaoRepository.UpdateMealAsync(updateMeal);
            return Ok("Refeição alterada com sucesso");
        }

        /// <summary>
        /// Excluir Refeição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpDelete]
        public IActionResult DeleteMeal(int id) 
        {
            _refeicaoRepository.Delete(id);
            return Ok("Refeição deletada com sucesso");
        }
    }
}
