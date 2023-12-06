using AutoMapper;
using UniversalWeahterForecast.BusinessLayer.DTOs.CelestalBodyDTOs;
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
            CreateMap<CreateWeatherForecastDTO, WeatherForecast>();
            CreateMap<CelestalBody, ViewCelestalBodyDTO>()
                .ForMember(
                    dest => dest.CelestalBodyType, opt => opt.MapFrom(src => src.IsPlanet ? "Planet" : "Satellite")
                ).ForMember(
                    dest => dest.AssociatedCelestalBody, opt => opt.MapFrom(src => src.WhoseSatellite)
                );
            CreateMap<CreateCelestalBodyDTO, CelestalBody>()
                .ForMember(
                    dest => dest.IsPlanet, opt => opt.MapFrom(src => src.CelestalBodyType)
                );
        }
    }
}
