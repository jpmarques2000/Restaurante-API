using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFMenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public EFMenuRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(AddMealToMenuDTO newMenuMeal)
        {
            var serviceResponse = new ServiceResponse<GetMenuDTO>();

            try
            {
                var menu = _context.Cardapio.FirstOrDefault(c => c.Id == newMenuMeal.cardapioId);

                if (menu is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Menu not found.";
                    return serviceResponse;
                }

                var meal = _context.Refeicao.FirstOrDefault(x => x.Id == newMenuMeal.refeicaoId);

                if (meal is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Meal not found.";
                    return serviceResponse;
                }

                menu.Refeicoes!.Add(meal);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMenuDTO>(menu);
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuDTO>> UpdateMenuAsync(UpdateMenuDTO updatedMenu)
        {
            var serviceResponse = new ServiceResponse<GetMenuDTO>();
            try
            {
                var menu = GetById(updatedMenu.Id);
                if (menu is null)
                    throw new Exception($"Não foi possível encontrar cadastro do menu com Id '{updatedMenu.Id}'.");

                menu.NomeCardapio = updatedMenu.NomeCardapio;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMenuDTO>(menu);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
