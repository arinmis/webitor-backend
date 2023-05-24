using AutoMapper;
using Core.Entities;
using Core.Features.Products.Commands.CreateProduct;
using Core.Features.Files.Commands.CreateFile;
using Core.Features.Products.Queries.GetAllProducts;
using Core.Features.Files.Queries.GetAllFiles;

namespace Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<File, GetAllFilesViewModel>().ReverseMap();
            CreateMap<CreateFileCommand, File>();
            CreateMap<GetAllFilesQuery, GetAllFilesParameter>();
        }
    }
}
