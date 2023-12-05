using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWeahterForecast.BusinessLayer.DTOs.WeatherForecastDTOs;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.WebApi.Mapping
{
    internal class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<WeatherForecast, ViewWeatherForecastDTO>()
                .ForMember(
                    dest => dest.BodyName, opt => opt.MapFrom(src => src.Body.Name)
                ).ForMember(
                    dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name)
                );
        }
    }
}
