using AutoMapper;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meal, GetMealDTO>();
            CreateMap<Menu, GetMenuDTO>();
            CreateMap<AddMenuDTO, Menu>();
        }
    }
}
