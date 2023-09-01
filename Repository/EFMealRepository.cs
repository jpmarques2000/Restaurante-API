using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFMealRepository : EFRepository<Meal>, IMealRepository
    {
        private readonly IMapper _mapper;
        public EFMealRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Meal GetOrders(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetMealDTO>> UpdateMealAsync(UpdateMealDTO updatedMeal)
        {
            var serviceResponse = new ServiceResponse<GetMealDTO>();
            try
            {
                var meal = _context.Refeicao.FirstOrDefault(m => m.Id == updatedMeal.Id);
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
    }
}
