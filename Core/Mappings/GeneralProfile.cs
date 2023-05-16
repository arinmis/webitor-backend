using AutoMapper;
using Core.Entities;
using Core.Features.Products.Commands.CreateProduct;
using Core.Features.Products.Queries.GetAllProducts;

namespace Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
