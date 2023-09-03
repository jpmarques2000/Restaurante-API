using AutoMapper;
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

        public Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(AddNewMenuMealDTO newMenuMeal)
        {
            throw new NotImplementedException();
        }

        //public async Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(MenuMeal menuMeal)
        //{
        //    var serviceResponse = new ServiceResponse<List<GetMenuDTO>>();

        //    _context.CardapioRefeicao.Add(menuMeal);
        //    await _context.SaveChangesAsync();

        //    //serviceResponse.Data =
        //    //    await _context.CardapioRefeicao.ToListAsync();

        //    //return serviceResponse;

        //    throw NotImplementedException();

        //}

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
