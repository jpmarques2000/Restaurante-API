using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Order;
using RestauranteAPI.DTO.OrderDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;
using RestauranteAPI.Repository;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<MealsController> _logger;

        public OrderController(IOrderRepository orderRepository, ILogger<MealsController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retorna listagem de pedidos
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<ICollection<GetOrderDTO>>>> GetOrders()
        {
            return Ok(await _orderRepository.GetAllOrders());
        }

        /// <summary>
        /// Retorna pedido a partir do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para realizar requisição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpGet("get-order-by-id/{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> GetOrderById(int id)
        {
            try
            {
                return Ok(await _orderRepository.GetOrderById(id));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao buscar pedido Id: {id}: {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Criar novo Pedido
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do usuário
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetOrderDTO>>>> 
            AddOrder(AddNewOrderDTO newOrder)
        {
            try
            {
                return Ok(await _orderRepository.CreateOrder(newOrder));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao criar novo pedido: {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Remover pedido existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do pedido a ser removido
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<ICollection<GetOrderDTO>>>>
            DeleteOrder(int id)
        {
            try
            {
                return Ok(await _orderRepository.DeleteOrder(id));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao excluir pedido Id: {id}: {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Adiciona refeição ao pedido
        /// </summary>
        /// <param name="newMeal"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Inserir Id do pedido e Id da refeição
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpPost("add-meal-to-order")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            AddOrderMeal(AddNewOrderMealDTO newMeal)
        {
            try
            {
                return Ok(await _orderRepository.AddOrderMeal(newMeal));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao adicionar refeição Id {newMeal.RefeicaoId}" +
                    $" ao pedido Id: {newMeal.PedidoId}: {ex.Message}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove refeição do pedido
        /// </summary>
        /// <param name="deletedMeal"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id da refeição a ser removida
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não Autenticado</response>
        /// <response code="403">Não Autorizado | Sem permissão</response>
        [Authorize]
        [HttpDelete("delete-meal-order")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>>
            DeleteOrderMeal(DeleteOrderMealDTO deletedMeal)
        {
            try
            {
                return Ok(await _orderRepository.DeleteOrderMeal(deletedMeal));
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"{DateTime.Now} | Erro ao excluir refeição Id {deletedMeal.RefeicaoId}" +
                    $" do pedido Id: {deletedMeal.PedidoId}: {ex.Message}");
                return BadRequest();
            }
        }
    }
}
