using Microsoft.AspNetCore.Authorization;
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

        public MealsController(IMealRepository refeicaoRepository,
            ILogger<MealsController> logger)
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
        [Authorize]
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
        [Authorize]
        [HttpGet("get-by-meal-id/{id}")]
        public async Task<ActionResult<ServiceResponse<GetMealDTO>>> GetByMealId(int id)
        {
            try
            {
                return Ok(await _refeicaoRepository.GetMealById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} | Falha ao procurar refeição por Id: {ex.Message}");
                return BadRequest();
            }
            
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMealDTO>>>> AddNewMeal(AddNewMealDTO refeicaoDTO)
        {
            try
            {
                return Ok(await _refeicaoRepository.AddMeal(refeicaoDTO));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao adicionar nova refeição: " +
                    $"{refeicaoDTO.Nome},: {ex.Message}");
                return BadRequest();
            }
            
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
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetMealDTO>>>> UpdateMeal(UpdateMealDTO updateMeal)
        {
            try
            {
                return Ok(await _refeicaoRepository.UpdateMeal(updateMeal));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao atualizar refeição: " +
                    $"{updateMeal.Nome}, Id {updateMeal.Id}: {ex.Message}");
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Excluir Refeição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetMealDTO>>> DeleteMeal(int id)
        {
            try
            {
                return Ok(await _refeicaoRepository.DeleteMeal(id));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao remover refeição Id: {id}: {ex.Message}");
                return BadRequest();
            }
            
        }
    }
}
