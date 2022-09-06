using AutoMapper;
using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.List
{
    public class DoctorAwardsAndRecognitionRequestHandler : IRequestHandler<DoctorAwardsAndRecognitionListRequestDTO, List<DoctorAwardsAndRecognitionDTO>>
    {
        private readonly IDoctorAwardsAndRecognitionRepository _repository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorAwardsAndRecognitionRequestHandler(IDoctorAwardsAndRecognitionRepository repository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorAwardsAndRecognitionDTO>> Handle(DoctorAwardsAndRecognitionListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorAwardsAndRecognitionDTO>>(await _repository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
