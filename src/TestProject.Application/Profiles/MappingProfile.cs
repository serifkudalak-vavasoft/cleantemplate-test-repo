using AutoMapper;
using TestProject.Domain.Entities;

// Categories
using TestProject.Application.Features.Categories.Queries.GetCategoriesList;
using TestProject.Application.Features.Categories.Commands.CreateCategory;
using TestProject.Application.Features.Categories.Commands.UpdateCategory;

// Products
using TestProject.Application.Features.Products.Queries.GetProductsList;
using TestProject.Application.Features.Products.Commands.CreateProduct;
using TestProject.Application.Features.Products.Commands.UpdateProduct;

namespace TestProject.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Categories
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            // Products
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
