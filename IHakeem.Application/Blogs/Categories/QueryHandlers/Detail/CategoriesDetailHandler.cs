using AutoMapper;
using iHakeem.Application.Blogs.Categories.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Blogs.Categories.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Blogs.Categories.QueryHandlers.Detail
{
    public class CategoriesDetailHandler : IRequestHandler<GetCategoriesRequestDTO, CategoriesResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly ICategoriesRepository _CategoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesDetailHandler(ICategoriesRepository CategoriesRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _CategoriesRepository = CategoriesRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<CategoriesResponseDTO> Handle(GetCategoriesRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _CategoriesRepository.GetSingle(request.Id);
            return _mapper.Map<CategoriesResponseDTO>(user);
        }
    }
}
