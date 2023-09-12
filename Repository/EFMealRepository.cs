using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFMealRepository : IMealRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EFMealRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetMealDTO>>> AddMeal(AddNewMealDTO newMeal)
        {
            var serviceResponse = new ServiceResponse<List<GetMealDTO>>();
            var meal = _mapper.Map<Meal>(newMeal);

            _context.Meal.Add(meal);
            await _context.SaveChangesAsync();

            serviceResponse.Data =
                await _context.Meal
                    .Where(m => m.Id == meal.Id)
                    .Select(meal => _mapper.Map<GetMealDTO>(meal))
                    .ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMealDTO>>> DeleteMeal(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetMealDTO>>();
            try
            {
                var meal = await GetById(id);
                if (meal is null)
                    throw new Exception($"Refeição com id '{id}' não encontrado");

                _context.Meal.Remove(meal);
                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Meal.Where(m => m.Id == id)
                    .Select(meal => _mapper.Map<GetMealDTO>(meal)).ToListAsync();

                serviceResponse.Message = "Refeição removida com sucesso!";
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMealDTO>>> GetAllMeal()
        {
            var serviceResponse = new ServiceResponse<List<GetMealDTO>>();

            var meal = await _context.Meal.ToListAsync();

            serviceResponse.Data = meal.Select(m => _mapper.Map<GetMealDTO>(m)).ToList();
            serviceResponse.Message = "Lista de refeições cadastradas";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMealDTO>> GetMealById(int id)
        {
            var serviceResponse = new ServiceResponse<GetMealDTO>();

            var meal = await _context.Meal.FirstOrDefaultAsync(m => m.Id == id);

            serviceResponse.Data = _mapper.Map<GetMealDTO>(meal);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMealDTO>> UpdateMeal(UpdateMealDTO updatedMeal)
        {
            var serviceResponse = new ServiceResponse<GetMealDTO>();
            try
            {
                var meal = _context.Meal.FirstOrDefault(m => m.Id == updatedMeal.Id);
                if (meal is null)
                    throw new Exception($"Refeição com Id '{updatedMeal.Id}' não foi encontrada, por favor verifique os dados.");

                meal.Nome = updatedMeal.Nome;
                meal.Descricao = updatedMeal.Descricao;
                meal.Preco = updatedMeal.Preco;
                
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMealDTO>(meal);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<Meal> GetById(int id)
        {
            var meal = await _context.Meal.FirstOrDefaultAsync(m => m.Id == id);
            if (meal is null)
                throw new Exception($"Refeição com id '{id}' não foi encontrado.");

            return meal;
        }
    }
}
