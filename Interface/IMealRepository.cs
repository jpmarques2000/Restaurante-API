using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IMealRepository
    {
        Task<ServiceResponse<GetMealDTO>> UpdateMeal(UpdateMealDTO updatedMeal);
        Task<ServiceResponse<List<GetMealDTO>>> GetAllMeal();
        Task<ServiceResponse<GetMealDTO>> GetMealById(int id);
        Task<ServiceResponse<List<GetMealDTO>>> AddMeal(AddNewMealDTO newMeal);
        Task<ServiceResponse<List<GetMealDTO>>> DeleteMeal(int id);
    }
}
