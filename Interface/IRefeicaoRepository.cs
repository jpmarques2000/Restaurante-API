using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Entity;

namespace RestauranteAPI.Interface
{
    public interface IRefeicaoRepository : IRepository<Refeicao>
    {
        Refeicao GetOrders(int id);

        Task<ServiceResponse<GetMealDTO>> UpdateMealAsync(UpdateMealDTO updatedMeal);
    }
}
