using AutoMapper;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.DTO.MenuDTO;
using RestauranteAPI.DTO.Order;
using RestauranteAPI.DTO.OrderDTO;
using RestauranteAPI.DTO.User;
using RestauranteAPI.DTO.UserDTO;
using RestauranteAPI.Models;

namespace RestauranteAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meal, GetMealDTO>();
            CreateMap<Menu, GetMenuDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<Order, GetOrderDTO>();
            CreateMap<AddMenuDTO, Menu>();
            CreateMap<AddNewUserDTO, User>();
            CreateMap<AddNewMealDTO, Meal>();
            CreateMap<AddNewOrderDTO, Order>();
            CreateMap<DeleteMealFromMenuDTO, Meal>();
            CreateMap<AddMealToMenuDTO, Meal>();
        }
    }
}
