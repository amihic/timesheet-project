using API.DTO;
using AutoMapper;
using System.Collections.Generic;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Model;

namespace API

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pagination<CategoryEntity>, IEnumerable<Category>>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CategoryEntity, CategoryDTO>();
            CreateMap<CategoryEntity, Category>();
            CreateMap<Task<Category>, Category>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryEntity>();

            CreateMap<SearchParamsDTO, SearchParams>();

            CreateMap<string, Country>().ConstructUsing(src => new Country { Name = src });
            ////////////////////////////////////////////////////////////////////////
            CreateMap<ClientDTO, Client>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => new Country
            {
                Name = src.Country
            }))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
            ////////////////////////////////////////////////////////////////////////
            CreateMap<CreateClientDTO, Client>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => new Country
            {
                Name = src.Country
            }))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
            ////////////////////////////////////////////////////////////////////////
            CreateMap<Client, ClientEntity>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country)).ReverseMap();

            CreateMap<Country, CountryEntity>().ReverseMap();

            CreateMap<CreateClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();



        }
    }
}
