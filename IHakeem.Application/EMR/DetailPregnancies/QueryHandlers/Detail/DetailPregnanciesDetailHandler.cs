using AutoMapper;
using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.DetailPregnancies.QueryHandlers.Detail
{
    public class DetailPregnanciesDetailHandler : IRequestHandler<GetDetailPregnanciesRequestDTO, DetailPregnanciesResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDetailPregnanciesRepository _DetailPregnanciesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DetailPregnanciesDetailHandler(IDetailPregnanciesRepository DetailPregnanciesRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _DetailPregnanciesRepository = DetailPregnanciesRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DetailPregnanciesResponseDTO> Handle(GetDetailPregnanciesRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _DetailPregnanciesRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<DetailPregnanciesResponseDTO>(user);
        }
    }
}
