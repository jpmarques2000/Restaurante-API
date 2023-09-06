using RestauranteAPI.DTO.Menu;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI.Interface
{
    public interface IMenuRepository 
    {
        Task<ServiceResponse<List<GetMenuDTO>>> GetAllMenus();
        Task<ServiceResponse<GetMenuDTO>> GetMenuById(int id);
        Task<ServiceResponse<List<GetMenuDTO>>> AddMenu(AddMenuDTO newMenu);
        Task<ServiceResponse<GetMenuDTO>> UpdateMenu(UpdateMenuDTO updatedMenu);
        Task<ServiceResponse<List<GetMenuDTO>>> DeleteMenu(int id);
        //Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(AddMealToMenuDTO newMenuMeal);
    }
}
