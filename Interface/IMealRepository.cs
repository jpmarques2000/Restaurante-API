using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IMealRepository : IRepository<Meal>
    {
        Meal GetOrders(int id);

        Task<ServiceResponse<GetMealDTO>> UpdateMealAsync(UpdateMealDTO updatedMeal);
    }
}
