using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.Menu;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFMenuRepository : IMenuRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EFMenuRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetMenuDTO>>> AddMenu(AddMenuDTO newMenu)
        {
            var serviceResponse = new ServiceResponse<List<GetMenuDTO>>();
            var menu = _mapper.Map<Menu>(newMenu);

            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Menu
                .Where(m => m.Id == menu.Id)
                .Select(m => _mapper.Map<GetMenuDTO>(m))
                .ToListAsync();

            serviceResponse.Message = "Menu adicionado com sucesso";

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuDTO>> AddNewMealToMenu(AddMealToMenuDTO newMenuMeal)
        {
            var serviceResponse = new ServiceResponse<GetMenuDTO>();
            try
            {
                var menu = await _context.Menu
                    .Include(m => m.Refeicoes)
                    .FirstOrDefaultAsync(m => m.Id == newMenuMeal.cardapioId);

                if (menu is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Menu não foi encontrado.";
                    return serviceResponse;
                }

                var meal = await _context.Meal
                    .FirstOrDefaultAsync(x => x.Id == newMenuMeal.refeicaoId);
                if (meal is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Refeição não encontrada.";
                    return serviceResponse;
                }

                menu.Refeicoes!.Add(meal);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMenuDTO>(menu);
                serviceResponse.Message = "Refeição adicionada ao menu com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMenuDTO>>> DeleteMenu(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetMenuDTO>>();

            try
            {
                //var menu = await _context.Menu
                //    .FirstOrDefaultAsync(m => m.Id == id);
                var menu = await GetById(id);
                if (menu is null)
                    throw new Exception($"Menu com id '{id}' não foi encontrado.");

                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Menu
                        .Where(m => m.Id == id)
                        .Select(m => _mapper.Map<GetMenuDTO>(m)).ToListAsync();

                serviceResponse.Message = "Menu removido com sucesso!";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuDTO>> UpdateMenu(UpdateMenuDTO updatedMenu)
        {
            var serviceResponse = new ServiceResponse<GetMenuDTO>();
            try
            {
                var menu = await _context.Menu.FirstOrDefaultAsync(m => m.Id == updatedMenu.Id);
                if (menu is null)
                    throw new Exception($"Não foi possível encontrar cadastro do menu com Id '{updatedMenu.Id}'.");

                menu.NomeCardapio = updatedMenu.NomeCardapio;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMenuDTO>(menu);
                serviceResponse.Message = "Menu atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMenuDTO>>> GetAllMenus()
        {
            var serviceResponse = new ServiceResponse<List<GetMenuDTO>>();

            var menus = await _context.Menu.Include(m => m.Refeicoes).ToListAsync();

            serviceResponse.Data = menus.Select(m => _mapper.Map<GetMenuDTO>(m)).ToList();
            serviceResponse.Message = "Listagem de Cardápios";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMenuDTO>> GetMenuById(int id)
        {
            var serviceResponse = new ServiceResponse<GetMenuDTO>();

            var menu = await _context.Menu.Include(m => m.Refeicoes).FirstOrDefaultAsync(m => m.Id == id);

            serviceResponse.Data = _mapper.Map<GetMenuDTO>(menu);

            return serviceResponse;
        }

        public async Task<Menu> GetById(int id)
        {
            var menu = await _context.Menu.FirstOrDefaultAsync(m => m.Id == id);
            if (menu is null)
                throw new Exception($"Menu com id '{id}' não foi encontrado.");

            return menu;
        }

        public async Task<ServiceResponse<List<GetMenuDTO>>> DeleteMealFromMenu(DeleteMealFromMenuDTO deletedMeal)
        {
            var serviceResponse = new ServiceResponse<List<GetMenuDTO>>();

            try
            {
                var id = deletedMeal.cardapioId;
                var menu = await GetById(id);
                if (menu is null)
                    throw new Exception($"Menu com id '{id}' não foi encontrado.");
                var meal = _mapper.Map<Meal>(deletedMeal);

                //_context.MealMenu.Remove(meal);
                menu.Refeicoes!.Remove(meal);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Menu
                        .Where(m => m.Id == id)
                        .Select(m => _mapper.Map<GetMenuDTO>(m)).ToListAsync();

                serviceResponse.Message = "Menu removido com sucesso!";
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
