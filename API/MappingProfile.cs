using API.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
            CreateMap<ClientDTO, Client>();

            ////////////////////////////////////////////////////////////////////////
            
            //za kreiranje Clienta
            CreateMap<CreateClientDTO, Client>()
            .ForPath(dest => dest.Country.Id, opt => opt.MapFrom(src => src.CountryId));

            CreateMap<Client, ClientEntity>()
            .ForPath(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
            //za prikaz Clienta
            CreateMap<Country, CountryEntity>().ReverseMap();
            CreateMap<CountryDTO, Country>();
            CreateMap<ClientEntity, Client>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForPath(dest => dest.Country.Id, opt => opt.MapFrom(src => src.Country.Id))
            .ForPath(dest => dest.Country.Name, opt => opt.MapFrom(src => src.Country.Name)).ReverseMap();

            CreateMap<Client, ClientDTO>()
                .ForPath(dest => dest.Country.Id, opt => opt.MapFrom(src => src.Country.Id))
                .ForPath(dest => dest.Country.Name, opt => opt.MapFrom(src => src.Country.Name));

            ////////////////////////////////////////////////////////////////////////
            ///
            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            ////////////////////////////////////////////////////////////////////////
            ///
            CreateMap<ProjectEntity, Project>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();

            //za kreiranje projekta
            CreateMap<CreateProjectDTO, Project>()
            .ForPath(dest => dest.Client.Id, opt => opt.MapFrom(src => src.ClientId))
            .ForPath(dest => dest.Lead.Id, opt => opt.MapFrom(src => src.LeadId));

            CreateMap<Project, ProjectEntity>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.Lead, opt => opt.MapFrom(src => src.Lead));

            //za prikaz projekta
            CreateMap<Client, ClientEntity>().ReverseMap();

            CreateMap<ProjectEntity, Project>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.Lead, opt => opt.MapFrom(src => src.Lead)).ReverseMap();

            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.Lead, opt => opt.MapFrom(src => src.Lead))
                .ForMember(dest => dest.UsersWorkingOn, opt => opt.MapFrom(src => src.UsersWorkingOn));

            ////////////////////////////////////////////////////////////////////////




        }
    }
}
