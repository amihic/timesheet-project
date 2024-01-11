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
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryEntity, Category>();
            

        }
    }
}
