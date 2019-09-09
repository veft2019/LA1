using System;
using AutoMapper;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewsItem, NewsItemDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<NewsItemInputModel, NewsItem>()
                .ForMember(src => src.DateCreated, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.DateModified, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(src => src.ModifiedBy, opt => opt.MapFrom(src => "TechnicalRadiationAdmin"));
        }
    }
}