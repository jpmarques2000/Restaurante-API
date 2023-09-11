using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.DTO.Order;
using RestauranteAPI.DTO.OrderDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetOrderDTO>> AddOrderMeal(AddNewOrderMealDTO newOrderMeal)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            try
            {
                var order = await _context.Order
                    .Include(o => o.Refeicao)
                    .FirstOrDefaultAsync(o => o.Id == newOrderMeal.PedidoId);

                if (order is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Pedido não encontrado";
                    return serviceResponse;
                }

                var meal = await _context.Meal
                    .FirstOrDefaultAsync(m => m.Id == newOrderMeal.RefeicaoId);
                if (meal is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Refeição não encontrada.";
                    return serviceResponse;
                }

                order.Refeicao!.Add(meal);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> CreateOrder(AddNewOrderDTO newOrder)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();
            var order = _mapper.Map<Order>(newOrder);

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Order
                .Where(o => o.Id == order.Id)
                .Select(o => _mapper.Map<GetOrderDTO>(o))
                .ToListAsync();

            serviceResponse.Message = "Pedido criado com sucesso.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> DeleteOrder(int id)
        {
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            try
            {
                var order = await _context.Order
                    .FirstOrDefaultAsync(o => o.Id == id);
                if (order is null)
                    throw new Exception($"Pedido com id '{id}' não foi encontrado.");

                _context.Order.Remove(order);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Order
                        .Where(o => o.Id == id)
                        .Select(o => _mapper.Map<GetOrderDTO>(o)).ToListAsync();

                serviceResponse.Message = "Pedido removido com sucesso!";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> DeleteOrderMeal(DeleteOrderMealDTO deletedMeal)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            try
            {
                var order = await _context.Order
                    .Include(o => o.Refeicao)
                    .FirstOrDefaultAsync(o => o.Id == deletedMeal.PedidoId);

                if (order is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Pedido não encontrado";
                    return serviceResponse;
                }

                var meal = await _context.Meal
                    .FirstOrDefaultAsync(m => m.Id == deletedMeal.RefeicaoId);
                if (meal is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Refeição não encontrada.";
                    return serviceResponse;
                }

                order.Refeicao!.Remove(meal);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
                serviceResponse.Message = "Refeição removida do pedido com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ICollection<GetOrderDTO>>> GetAllOrders()
        { 
            var serviceResponse = new ServiceResponse<ICollection<GetOrderDTO>>();

            var orders = await _context.Order.Include(o => o.Refeicao).ToListAsync();

            serviceResponse.Data = orders.Select(o => _mapper.Map<GetOrderDTO>(o)).ToList();
            serviceResponse.Message = "Listagem de pedidos";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();

            var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == id);

            serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);

            return serviceResponse;
        }
    }
}
