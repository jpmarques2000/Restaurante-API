using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO.Order;
using RestauranteAPI.DTO.OrderDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

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
        [HttpGet("get-order-by-id/{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> GetOrderById(int id)
        {
            return Ok(await _orderRepository.GetOrderById(id));
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
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ICollection<GetOrderDTO>>>> 
            AddOrder(AddNewOrderDTO newOrder)
        {
            return Ok(await _orderRepository.CreateOrder(newOrder));
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
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<ICollection<GetOrderDTO>>>>
            DeleteOrder(int id)
        {
            return Ok(await _orderRepository.DeleteOrder(id));
        }
    }
}
