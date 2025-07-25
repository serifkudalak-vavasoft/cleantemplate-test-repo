using AutoMapper;
using TestProject.Application.Features.AutoParts.Commands.CreateAutoPart;
using TestProject.Application.Features.AutoParts.Commands.UpdateAutoPart;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartDetail;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartsList;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport;
using TestProject.Application.Features.Categories.Commands.CreateCateogry;
using TestProject.Application.Features.Categories.Queries.GetCategoriesList;
using TestProject.Application.Features.Categories.Queries.GetCategoriesListWithAutoParts;
using TestProject.Application.Features.Orders.Queries.GetOrdersForMonth;
using TestProject.Domain.Entities;

namespace TestProject.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutoPart, AutoPartListVm>().ReverseMap();
            CreateMap<AutoPart, AutoPartDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryAutoPartListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<AutoPart, CategoryAutoPartDto>().ReverseMap();
            CreateMap<AutoPart, AutoPartExportDto>().ReverseMap();

            CreateMap<AutoPart, CreateAutoPartCommand>().ReverseMap();
            CreateMap<AutoPart, UpdateAutoPartCommand>().ReverseMap();
            CreateMap<AutoPart, CategoryAutoPartDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
