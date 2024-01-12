using API.DTO;
using AutoMapper;
using System.Collections.Generic;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Model;

namespace API

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDTO>();
            CreateMap<CategoryEntity, Category>();
            CreateMap<Task<Category>, Category>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryEntity>();


        }
    }
}
