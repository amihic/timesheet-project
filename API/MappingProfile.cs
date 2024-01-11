using API.DTO;
using AutoMapper;
using TimeSheet.Data.Entities;
using TimeSheet.Domain.Model;

namespace API

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryEntity, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

        }
    }
}
