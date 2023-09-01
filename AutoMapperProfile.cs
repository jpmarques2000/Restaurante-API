using AutoMapper;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Entity;

namespace RestauranteAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Refeicao, GetMealDTO>();
        }
    }
}
