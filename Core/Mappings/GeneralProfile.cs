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
            CreateMap<CreateFileCommand, File>();
        }
    }
}
