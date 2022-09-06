using AutoMapper;
using iHakeem.Application.Doctors.DoctorServices.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Services.QueryHandler.Detail
{
    public class DoctorServiceDetailHandler : IRequestHandler<DoctorServiceDetailRequestDTO, DoctorServiceDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorServiceRepository _doctorServiceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorServiceDetailHandler(IDoctorServiceRepository doctorServiceRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorServiceRepository = doctorServiceRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorServiceDTO> Handle(DoctorServiceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorServiceDTO>(await _doctorServiceRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false));
        }
    }
}
