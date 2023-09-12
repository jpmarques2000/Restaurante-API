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
        /// Obtém todas as refeições cadastradas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetMealDTO>>>> GetAllMeals()
        {
            return Ok(await _refeicaoRepository.GetAllMeal());
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
        public async Task<ActionResult<ServiceResponse<GetMealDTO>>> GetByMealId(int id)
        {
            return Ok(await _refeicaoRepository.GetMealById(id));
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
        public async Task<ActionResult<ServiceResponse<List<GetMealDTO>>>> AddNewMeal(AddNewMealDTO refeicaoDTO)
        {
            return Ok(await _refeicaoRepository.AddMeal(refeicaoDTO));
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
        public async Task<ActionResult<ServiceResponse<List<GetMealDTO>>>> UpdateMeal(UpdateMealDTO updateMeal)
        {
            return Ok(await _refeicaoRepository.UpdateMeal(updateMeal));
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
        public async Task<ActionResult<ServiceResponse<GetMealDTO>>> DeleteMeal(int id)
        {
            return Ok(await _refeicaoRepository.DeleteMeal(id));
        }
    }
}
