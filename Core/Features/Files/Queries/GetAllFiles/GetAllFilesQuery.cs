using AutoMapper;

using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Queries.GetAllFiles
{
    public class GetAllFilesQuery : IRequest<PagedResponse<IEnumerable<GetAllFilesViewModel>>>
    {   public string UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, PagedResponse<IEnumerable<GetAllFilesViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllFilesQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFilesViewModel>>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFilesParameter>(request);
            var product = await _productRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<GetAllFilesViewModel>>(product);
            return new PagedResponse<IEnumerable<GetAllFilesViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
