using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<ServiceResponse<GetMenuDTO>> UpdateMenuAsync(UpdateMenuDTO updatedMenu);
        Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(AddNewMenuMealDTO newMenuMeal);
    }
}
