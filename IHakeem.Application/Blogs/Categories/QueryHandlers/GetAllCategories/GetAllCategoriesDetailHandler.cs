using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.Blogs.Categories.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.Categories;
using iHakeem.Domain.Blogs.Categories.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.Blogs.Categories.QueryHandlers.Detail
{
    public class GetAllCategoriesDetailHandler : IRequestHandler<GetAllCategoriesDetailRequestDTO, List<CategoriesResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _CategoriesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllCategoriesDetailHandler(ICategoriesRepository CategoriesRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _CategoriesRepository = CategoriesRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<CategoriesResponseDTO>> Handle(GetAllCategoriesDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _CategoriesRepository.GetAll();
            return _mapper.Map<List<CategoriesResponseDTO>>(user);
        }
    }
}
