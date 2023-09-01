﻿using AutoMapper;
using RestauranteAPI.DTO.Meal;
using RestauranteAPI.Models;

namespace RestauranteAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meal, GetMealDTO>();
        }
    }
}
