using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.Order;
using RestauranteAPI.DTO.OrderDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IOrderRepository
    {
        Task<ServiceResponse<ICollection<GetOrderDTO>>> GetAllOrders();
        Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> CreateOrder(AddNewOrderDTO newOrder);
        Task<ServiceResponse<ICollection<GetOrderDTO>>> DeleteOrder(int id);
        Task<ServiceResponse<GetOrderDTO>> AddOrderMeal(AddNewOrderMealDTO newOrderMeal);
    }
}
